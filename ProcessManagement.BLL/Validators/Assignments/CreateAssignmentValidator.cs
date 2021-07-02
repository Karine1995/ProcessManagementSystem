using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ProcessManagement.BLL.Infrastructure;
using ProcessManagement.Common.Helpers;
using ProcessManagement.DAL.Infrastructure;
using ProcessManagement.Entities.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessManagement.BLL.Validators.Users
{
    internal class CreateAssignmentValidator : EntityValidator<Assignment>
    {
        public CreateAssignmentValidator(ProcessManagementDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task ValidateAsync(Assignment assignment)
        {
            var errors = new Dictionary<string, string[]>();
           
            if (!await DbContext.Users.AnyAsync(u => u.Id == assignment.AssigneeId))
                errors.Add("assigneeId", new[] { "User not found" });

            if (!await DbContext.Projects.AnyAsync(p => p.Id == assignment.ProjectId))
                errors.Add("projectId", new[] { "Project not found" });

            if (errors.Any())
                ExceptionHelper.ThrowFaultException("Bad request", StatusCodes.Status400BadRequest, errors);
        }
    }
}
