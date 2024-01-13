using BlogApi.Models.DTO;
using FluentValidation;

namespace BlogApi.Validators;

public class CreateBlogValidator : AbstractValidator<CreateBlogPostRequest>
{
    public CreateBlogValidator()
    {
        RuleFor(bp => bp.Title)
            .NotEmpty()
            .WithMessage("Title is required")
            .Length(5, 100)
            .WithMessage("Length must be between 3 and 100");

        RuleFor(bp => bp.Content)
            .NotEmpty()
            .WithMessage("Content is required")
            .MaximumLength(250)
            .WithMessage("Maximum length is 250");
    }
}