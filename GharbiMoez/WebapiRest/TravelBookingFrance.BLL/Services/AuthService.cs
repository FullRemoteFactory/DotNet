using aspnetcore.ntier.DAL.Repositories.IRepositories;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TravelBookingFrance.BLL.Services.IServices;
using TravelBookingFrance.BLL.Utilities.CustomExceptions;
using TravelBookingFrance.DAL.Entities;
using TravelBookingFrance.DTO.DTOs;

namespace TravelBookingFrance.BLL.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;
    public AuthService(
        IUserRepository userRepository,
        IMapper mapper,
        IConfiguration configuration)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _configuration = configuration;
    }

    public async Task<UserToReturnDTO> LoginAsync(UserToLoginDTO userToLoginDTO)
    {
        var user = await _userRepository.GetAsync(
            u => u.Username == userToLoginDTO.Username.ToLower() && u.Password == userToLoginDTO.Password);

        if (user == null)
            throw new UserNotFoundException();

        var userToReturn = _mapper.Map<UserToReturnDTO>(user);
        userToReturn.Token = GenerateToken(user.UserId, user.Username);
        userToReturn.IsAuthenticated = true;

        return userToReturn;
    }

    public async Task<UserToReturnDTO> RegisterAsync(UserToRegisterDTO userToRegisterDTO)
    {
        userToRegisterDTO.Username = userToRegisterDTO.Username.ToLower();

        var addedUser = await _userRepository.AddAsync(_mapper.Map<Customer>(userToRegisterDTO));

        var userToReturn = _mapper.Map<UserToReturnDTO>(addedUser);
        userToReturn.Token = GenerateToken(addedUser.UserId, addedUser.Username);

        return userToReturn;
    }

    private string GenerateToken(int userId, string username)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
            new Claim(ClaimTypes.Name, username)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(1),
            SigningCredentials = creds
        };

        var tokenHandler = new JwtSecurityTokenHandler();

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}