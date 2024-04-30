using FluentValidation;
using TaxReporter.DTOs.User;

namespace TaxReporter.Validators.User
{
    public class CreateUserValidator : AbstractValidator<CreateUser>
    {
        public CreateUserValidator()
        {
            RuleFor(user => user.IdentificationCard)
                .NotEmpty().WithMessage("The identification card is required")
                .MaximumLength(50).WithMessage("The identification card cannot exceed 50 characters");

            RuleFor(user => user.FullName)
                .NotEmpty().WithMessage("The full name is required")
                .MaximumLength(50).WithMessage("The full name cannot exceed 50 characters");

            RuleFor(user => user.Age)
                .NotEmpty().WithMessage("The age is required")
                .InclusiveBetween(18, 70).WithMessage("The age must be between 18 and 70 years");

            RuleFor(user => user.PhoneNumber)
                .NotEmpty().WithMessage("The phone number is required")
                .MaximumLength(15).WithMessage("The phone number cannot exceed 15 characters");

            RuleFor(user => user.Email)
                .NotEmpty().WithMessage("The email is required")
                .MaximumLength(100).WithMessage("The email cannot exceed 100 characters");

            RuleFor(user => user.UserPassword)
                .NotEmpty().WithMessage("The password is required")
                .MaximumLength(100).WithMessage("The password cannot exceed 100 characters");

            RuleFor(user => user.RolId)
                .NotEmpty().WithMessage("The role ID is required")
                .InclusiveBetween(1, 4).WithMessage("The role must be between 1 and 4");

            RuleFor(user => user.JobTitle)
                .NotEmpty().WithMessage("The job title is required")
                .MaximumLength(50).WithMessage("The job title cannot exceed 50 characters");

            RuleFor(user => user.IsActive)
                .NotNull().WithMessage("The active state is required")
                .InclusiveBetween(0, 1).WithMessage("The state must be between 0 and 1");

        }

    }

}
