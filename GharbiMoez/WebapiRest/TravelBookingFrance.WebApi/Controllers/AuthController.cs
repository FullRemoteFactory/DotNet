using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TravelBookingFrance.BLL.Services.IServices;
using TravelBookingFrance.BLL.Utilities.CustomExceptions;
using TravelBookingFrance.DAL.UnitOfWorks;
using TravelBookingFrance.DTO.DTOs;

namespace TravelBookingFrance.WebApi.Controllers;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1")]
[ApiController]
public class AuthController : ControllerBase
{
    private IMapper _mapper;
    private readonly IAuthService _authService;
    private readonly IUnitOfWork _unitOfWork;
    public AuthController(IAuthService authService, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _authService = authService;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public IMapper Mapper { get; }

    [HttpPost("login")]
    public async Task<IActionResult> Login(UserToLoginDTO userToLoginDTO)
    {
        try
        {
            var user = await _authService.LoginAsync(userToLoginDTO);
            UserToReturnDTO userReturn = new UserToReturnDTO
            {
                UserId = user.UserId,
                Username = user.Username,
                Name = user.Name,
                Surname = user.Surname,
                Token = user.Token,
                IsAuthenticated = user.IsAuthenticated
            };
            /* var result = await _unitOfWork.Travels.GetAllTravelByCustomerIdAsync(user.UserId);
             var resultMap = _mapper.Map<IEnumerable<GetTravelListByCustomerIdDTO>>(result);
             UserAndRelatedInformation userAndRelatedInformation = new UserAndRelatedInformation
             {
                 UserId = user.UserId,
                 Username = user.Username,
                 Name = user.Name,
                 Surname = user.Surname,
                 Token = user.Token,
                 TravelListForCostomer = resultMap

             };*/

            return Ok(userReturn);
        }
        catch (UserNotFoundException)
        {
            return Unauthorized();
        }
        catch (Exception)
        {
            return BadRequest("Something went wrong");
        }
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(UserToRegisterDTO userToRegisterDTO)
    {
        try
        {
            return Ok(await _authService.RegisterAsync(userToRegisterDTO));
        }
        catch (Exception)
        {
            return BadRequest("Something went wrong");
        }
    }
}
