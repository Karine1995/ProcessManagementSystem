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

namespace ProcessManagement.BLL.Validators.Teams
{
    internal class CreateTeamValidator : EntityValidator<Team>
    {
        public CreateTeamValidator(ProcessManagementDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task ValidateAsync(Team team)
        {
            var errors = new Dictionary<string, string[]>();

            //if (await DbContext.Users.AnyAsync(u => u.Username == user.Username))
            //    errors.Add("username", new[] { "Username already exists" });

            //if (await DbContext.Users.AnyAsync(u => u.Email == user.Email))
            //    errors.Add("email", new[] { "Email already exists" });

            if (errors.Any())
                ExceptionHelper.ThrowFaultException("Bad request", StatusCodes.Status400BadRequest, errors);
        }
    }
}
