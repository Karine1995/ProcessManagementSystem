using FluentValidation;
using ProcessManagement.IdentityServer4.Common.Models.Inputs;

namespace ProcessManagement.IdentityServer4.Validators
{
    public class RegisterUserValidator : AbstractValidator<RegisterUser>
    {
        public RegisterUserValidator()
        {
            RuleFor(u => u.Username)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty()
                .MaximumLength(256);

            RuleFor(u => u.Email)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty()
                .MaximumLength(256);

            RuleFor(u => u.Password)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();
        }
    }
}
