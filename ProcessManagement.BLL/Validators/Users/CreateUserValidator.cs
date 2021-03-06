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
    internal class CreateUserValidator : EntityValidator<User>
    {
        public CreateUserValidator(ProcessManagementDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task ValidateAsync(User user)
        {
            var errors = new Dictionary<string, string[]>();

            if (await DbContext.Users.AnyAsync(u => u.Username == user.Username))
                errors.Add("username", new[] { "Username already exists" });

            if (await DbContext.Users.AnyAsync(u => u.Email == user.Email))
                errors.Add("email", new[] { "Email already exists" });

            if (errors.Any())
                ExceptionHelper.ThrowFaultException("Bad request", StatusCodes.Status400BadRequest, errors);
        }
    }
}
