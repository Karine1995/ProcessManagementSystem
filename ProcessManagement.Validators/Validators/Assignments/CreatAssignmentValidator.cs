using FluentValidation;
using ProcessManagement.Common.Models.Inputs.Assignments;

namespace ProcessManagement.Validators.Validators
{
    class CreateAssignmentValidator : AbstractValidator<CreateAssignmentInput>
    {
        public CreateAssignmentValidator()
        {
            RuleFor(u => u.ProjectId)
                .NotNull()
                .NotEmpty();
    
            RuleFor(u => u.Title)
                .NotNull()
                .NotEmpty()
                .MaximumLength(255);

            RuleFor(u => u.Description)
                .NotNull()
                .NotEmpty()
                .MaximumLength(1000);

            RuleFor(u => u.AssigneeId)
                .NotNull()
                .NotEmpty();

        }
    }
}
