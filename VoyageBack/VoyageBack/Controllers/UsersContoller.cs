using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using VoyageBack.Dtos;
using VoyageBack.Models;
using VoyageBack.Services;

namespace VoyageBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
         private readonly IConfiguration config;
        private readonly EmailService _emailService;
        public UsersController(UserManager<User> userManager, IConfiguration configuration, EmailService emailService)
        {
            _userManager = userManager;
            _configuration = configuration;
            _emailService = emailService;
            config = configuration;
        }



        [HttpPost("RegisterUser")]
        public async Task<ActionResult<UserDto>> Register([FromForm] UserDto userDto)
        {
            // Check if email already exists
            if (_userManager.Users.Any(u => u.Email == userDto.Email))
            {
                return BadRequest(new { Message = "Email already exists." });
            }
            // Check if the email address is valid
            if (!IsValidEmail(userDto.Email))
            {
                return BadRequest("Invalid email address.");
            }
            // Upload Logo/Photo
            if (userDto.File is not null)
            {
                if (userDto.File.Length > (10 * 1024 * 1024))
                {
                    return BadRequest(new { Message = "maxFileSize" });
                }

                string logo = Guid.NewGuid().ToString() + Path.GetExtension(userDto.File.FileName);
                var fileStream = new FileStream(Path.Combine(@"wwwroot/", "images/", logo), FileMode.Create);
                userDto.File.CopyTo(fileStream);
                fileStream.Close();
                userDto.FileName = logo;
            }

          

            // Create a new user object with uploaded file paths
            var user = new User
            {
                Email = userDto.Email,
               
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                PasswordHash = userDto.Password,
                  Age=userDto.Age,                                                                                                                          
                PhoneNumber = userDto.PhoneNumber,
                Adress = userDto.Adress,
                City = userDto.City,
                ZipCode = userDto.ZipCode,
                Country = userDto.Country,
                LogoFilePath = "wwwroot/images/" + userDto.FileName,
               UserName = userDto.FirstName+ "." + userDto.LastName,                                                                                        
                FileName = userDto.FileName,
                DateOfBirthday=userDto.DateOfBirthday,
                Civility = userDto.Civility,
               
               
            };
            // Save the user to the database
            var result = await _userManager.CreateAsync(user, userDto.Password);

            if (result.Succeeded)
            {
                

                await _emailService.SendEmailAsync(userDto.Email, userDto.Password);

                return Ok(new { Message = "User Added Successfully" });
            }

            // If user creation fails, return the errors
            return BadRequest(new { Message = "User creation failed.", Errors = result.Errors });
        }







        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return Unauthorized(); // Invalid email
            }

            var result = await _userManager.CheckPasswordAsync(user, model.Password);
            if (!result)
            {
                return Unauthorized(); // Invalid password
            }

            var roles = await _userManager.GetRolesAsync(user); // Get roles for the user
            var token = GenerateToken(user, roles.ToList());
            return Ok(new { Token = token, Email = user.Email, Roles = roles, Username = user.UserName });
        }

        private string GenerateToken(User user, IList<string> roles)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            // Replace with your secret key
            var key = Encoding.ASCII.GetBytes(config["JWT:Key"]);

            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.NameIdentifier, user.Id),
        new Claim(ClaimTypes.Name, user.UserName), // Change to username
        new Claim(ClaimTypes.Email, user.Email), // Include email claim
        // Add more claims as needed
    };

            // Include role claims
            if (roles != null && roles.Any())
            {
                claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(1), // Set expiration time
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }



        private bool IsValidEmail(string email)
        {
            // Define a regular expression pattern for email validation
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            // Check if the email matches the pattern
            if (Regex.IsMatch(email, pattern))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //    /**************************************
        // * 
        // * Strong Password 
        // * 
        // * ****/

        private string CheckPasswordStrength(string password)
        {
            StringBuilder sb = new StringBuilder();
            if (password.Length < 4)
            {
                sb.Append("Minimum password length should be 8." + Environment.NewLine);
            }
            if (!(Regex.IsMatch(password, "[a-z]") && Regex.IsMatch(password, "[A-Z]") && Regex.IsMatch(password, "[0-9]")))
            {
                sb.Append("Password should be Alphanumeric." + Environment.NewLine);
            }

            if (!(Regex.IsMatch(password, "[<,>,@,!,#,$,%,^,&,*,(,),_,+,\\],\\[,{,},?,:,;,|,',\\,.,/,~,`,-,=]")))
            {
                sb.Append("Password should contain special character." + Environment.NewLine);
            }
            return sb.ToString();
        }



        [HttpGet("user-info")]
        public async Task<ActionResult<UserDto>> GetCurrentUserInfo()
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var currentUser = await _userManager.FindByIdAsync(currentUserId);

            if (currentUser == null)
            {
                return NotFound();
            }

            var userInfoDto = new UserDto
            {
               
                FirstName = currentUser.FirstName,
                LastName = currentUser.LastName,
                
                Civility=currentUser.Civility,          
                FileName = currentUser.FileName,
                Adress = currentUser.Adress,
               Age= currentUser.Age,                                            
                City = currentUser.City,
                ZipCode = currentUser.ZipCode,
                Country = currentUser.Country,
                PhoneNumber = currentUser.PhoneNumber,
                Email = currentUser.Email,
                
            };

            return Ok(userInfoDto);
        }

    }
}
