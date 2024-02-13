using FluentValidation;
using TravelBookingFrance.DTO.DTOs;

namespace TravelBookingFrance.BLL.Validators;

public class UserToRegisterDTOValidator : AbstractValidator<UserToRegisterDTO>
{
    public UserToRegisterDTOValidator()
    {
        RuleFor(x => x.Username).NotEmpty();
        RuleFor(x => x.Password).NotEmpty();
    }
}

