using FluentValidation;
using ProcessManagement.Common.Models.Inputs.Teams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessManagement.Validators.Validators.Teams
{
    class CreateTeamValidator : AbstractValidator<CreateTeamInput>
    {
        public CreateTeamValidator()
        {
            //RuleFor(u => u.Id)
            //    .NotNull()
            //    .NotEmpty();

            RuleFor(u => u.Name)
                .NotNull()
                .NotEmpty()
                .MaximumLength(25);

        }
    }
}
