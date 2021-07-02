using Microsoft.AspNetCore.Http;
using ProcessManagement.BLL.Infrastructure;
using ProcessManagement.Common.Helpers;
using ProcessManagement.DAL.Infrastructure;
using ProcessManagement.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using userType = ProcessManagement.Common.Enumerations.UserTypes;

namespace ProcessManagement.BLL.Validators.Projects
{
    internal class DeleteProjectValidator : EntityValidator<Project>
    {
        public DeleteProjectValidator(ProcessManagementDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task ValidateAsync(Project project)
        {
            var errors = new Dictionary<string, string[]>();

            if (project.User.Type != userType.ProjectManager)
                errors.Add("type", new[] { "You don't have permission" });
            
            if (errors.Any())
                ExceptionHelper.ThrowFaultException("Bad request", StatusCodes.Status400BadRequest, errors);
        }
    }
}
