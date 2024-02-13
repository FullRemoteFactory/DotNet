using TravelBookingFrance.DTO.DTOs;

namespace TravelBookingFrance.BLL.Services.IServices;

public interface IAuthService
{
    Task<UserToReturnDTO> LoginAsync(UserToLoginDTO userToLoginDTO);
    Task<UserToReturnDTO> RegisterAsync(UserToRegisterDTO userToRegisterDTO);
}
