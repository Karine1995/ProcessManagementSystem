using FluentValidation;
using ProcessManagement.Common.Models.Inputs.Projects;

namespace ProcessManagement.Validators.Validators.Projects
{
    public class CreateProjectValidator : AbstractValidator<CreateProjectInput>
    {
        public CreateProjectValidator()
        {
            RuleFor(u => u.Description)
                .NotNull()
                .NotEmpty()
                .MaximumLength(1000);

            RuleFor(u => u.Name)
                .NotNull()
                .NotEmpty();
        }
    }
}
