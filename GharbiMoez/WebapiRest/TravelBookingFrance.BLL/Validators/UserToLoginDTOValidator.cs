using FluentValidation;
using TravelBookingFrance.DTO.DTOs;

namespace TravelBookingFrance.BLL.Validators;

public class UserToLoginDTOValidator : AbstractValidator<UserToLoginDTO>
{
    public UserToLoginDTOValidator()
    {
        RuleFor(x => x.Username).NotEmpty();
        RuleFor(x => x.Password).NotEmpty();
    }
}
