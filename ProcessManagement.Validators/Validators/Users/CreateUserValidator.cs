using FluentValidation;
using ProcessManagement.Common.Models.Inputs.Users;
using ProcessManagement.Validators.CustomValidators;

namespace ProcessManagement.Validators.Validators.Users
{
    public class CreateUserValidator : AbstractValidator<CreateUserInput>
    {
        public CreateUserValidator()
        {
            RuleFor(u => u.Username)
                .NotNull()
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(u => u.FirstName)
                .NotNull()
                .NotEmpty()
                .MaximumLength(25);

            RuleFor(u => u.LastName)
                .NotNull()
                .NotEmpty()
                .MaximumLength(25);

            RuleFor(u => u.Type)
                .NotNull()
                .NotEmpty()
                .IsInEnum();

            RuleFor(u => u.Email)
                .NotNull()
                .NotEmpty()
                .MaximumLength(50)
                .EmailAddress();

            RuleFor(u => u.Password)
                .NotNull()
                .NotEmpty()
                .Password();
        }
    }
}
