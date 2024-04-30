using FluentValidation;
using TaxReporter.DTOs.User;

namespace TaxReporter.Validators.Auth
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(request => request.Email)
                .NotEmpty()
                .WithMessage("Email is required");

            RuleFor(request => request.UserPassword)
                .NotEmpty()
                .WithMessage("Password is required");

        }

    }

}
