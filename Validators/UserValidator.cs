using BlogApi.Models.DTO;
using FluentValidation;

namespace BlogApi.Validators;

public class UserValidator : AbstractValidator<UserDTO>
{
    public UserValidator()
    {
        RuleFor(dto => dto.Id).NotEmpty()
            .WithMessage("Id is required")
            .NotNull()
            .WithMessage("Id cannot be null");
        RuleFor(dto => dto.Email)
            .NotEmpty()
            .WithMessage("Email is required")
            //.Matches(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")
            .EmailAddress()
            .WithMessage("Invalid email address format.");
    }
}