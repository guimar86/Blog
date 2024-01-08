using BlogApi.Models.DTO;
using FluentValidation;

namespace BlogApi.Validators;

public class CreateUserValidator : AbstractValidator<UserCreateDTO>
{
    public CreateUserValidator()
    {
        RuleFor(d => d.Email)
            .NotEmpty()
            .WithMessage("Email is required")
            //.Matches(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")
            .EmailAddress()
            .WithMessage("Invalid email address format.");
        RuleFor(d => d.Username)
            .NotEmpty()
            .WithMessage("Username is required");
    }
}