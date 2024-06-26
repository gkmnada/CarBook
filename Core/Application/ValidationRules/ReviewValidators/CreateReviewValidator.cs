using Application.Features.Mediator.Commands.ReviewCommands;
using FluentValidation;

namespace Application.ValidationRules.ReviewValidators
{
    public class CreateReviewValidator : AbstractValidator<CreateReviewCommand>
    {
        public CreateReviewValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Name must be at least 2 characters");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Name cannot exceed 50 characters");
            RuleFor(x => x.Comment).NotEmpty().WithMessage("Comment is required");
            RuleFor(x => x.Comment).MaximumLength(500).WithMessage("Comment cannot exceed 500 characters");
            RuleFor(x => x.Rating).InclusiveBetween(1, 5).WithMessage("Rating must be between 1 and 5");
        }
    }
}
