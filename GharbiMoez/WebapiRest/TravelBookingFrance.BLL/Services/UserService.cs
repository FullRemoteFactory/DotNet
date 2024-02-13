using aspnetcore.ntier.DAL.Repositories.IRepositories;
using AutoMapper;
using Microsoft.Extensions.Logging;
using TravelBookingFrance.BLL.Services.IServices;
using TravelBookingFrance.BLL.Utilities.CustomExceptions;
using TravelBookingFrance.DAL.Entities;
using TravelBookingFrance.DTO.DTOs;

namespace TravelBookingFrance.BLL.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<UserService> _logger;

    public UserService(IUserRepository userRepository, IMapper mapper, ILogger<UserService> logger)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<List<UserDTO>> GetUsersAsync(CancellationToken cancellationToken = default)
    {
        var usersToReturn = await _userRepository.GetListAsync(cancellationToken: cancellationToken);
        _logger.LogInformation("List of {Count} users has been returned", usersToReturn.Count);

        return _mapper.Map<List<UserDTO>>(usersToReturn);
    }

    public async Task<UserDTO> GetUserAsync(int userId, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("User with userId = {UserId} was requested", userId);
        var userToReturn = await _userRepository.GetAsync(x => x.UserId == userId, cancellationToken);

        if (userToReturn is null)
        {
            _logger.LogError("User with userId = {UserId} was not found", userId);
            throw new UserNotFoundException();
        }

        return _mapper.Map<UserDTO>(userToReturn);
    }

    public async Task<UserDTO> AddUserAsync(UserToAddDTO userToAddDTO)
    {
        userToAddDTO.Username = userToAddDTO.Username.ToLower();
        var addedUser = await _userRepository.AddAsync(_mapper.Map<Customer>(userToAddDTO));

        return _mapper.Map<UserDTO>(addedUser);
    }

    public async Task<UserDTO> UpdateUserAsync(UserToUpdateDTO userToUpdateDTO)
    {
        userToUpdateDTO.Username = userToUpdateDTO.Username.ToLower();
        var user = await _userRepository.GetAsync(x => x.UserId == userToUpdateDTO.UserId);

        if (user is null)
        {
            _logger.LogError("User with userId = {UserId} was not found", userToUpdateDTO.UserId);
            throw new UserNotFoundException();
        }

        var userToUpdate = _mapper.Map<Customer>(userToUpdateDTO);

        _logger.LogInformation("User with these properties: {@UserToUpdate} has been updated", userToUpdateDTO);

        return _mapper.Map<UserDTO>(await _userRepository.UpdateUserAsync(userToUpdate));
    }

    public async Task DeleteUserAsync(int userId)
    {
        var userToDelete = await _userRepository.GetAsync(x => x.UserId == userId);

        if (userToDelete is null)
        {
            _logger.LogError("User with userId = {UserId} was not found", userId);
            throw new UserNotFoundException();
        }

        await _userRepository.DeleteAsync(userToDelete);
    }
}