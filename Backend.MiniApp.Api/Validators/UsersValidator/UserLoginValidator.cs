using Backend.MiniApp.Api.Dtos.Users;
using FluentValidation;

namespace Backend.MiniApp.Api.Validators.UsersValidator;

public class UserLoginValidator: AbstractValidator<UserLoginDto>
{
    public UserLoginValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty().WithMessage("Username is required.")
            .MaximumLength(50).WithMessage("Username must not exceed 50 characters.");
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.");
    }
}
