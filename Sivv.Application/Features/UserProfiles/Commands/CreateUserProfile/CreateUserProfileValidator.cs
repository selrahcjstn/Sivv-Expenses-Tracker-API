using FluentValidation;

namespace Sivv.Application.Features.UserProfiles.Commands.CreateUserProfile
{
    public class CreateUserProfileValidator : AbstractValidator<CreateUserProfileCommand>
    {
        public CreateUserProfileValidator() 
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required.")
                .MaximumLength(50).WithMessage("First name cannot exceed 50 characters.");
            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required.")
                .MaximumLength(50).WithMessage("Last name cannot exceed 50 characters.");
            RuleFor(x => x.BirthDate)
                .NotEmpty().WithMessage("Birth date is required.")
                .LessThan(DateOnly.FromDateTime(DateTime.Now)).WithMessage("Birth date must be in the past.");
        }
    }
}
