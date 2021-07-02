using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ProcessManagement.BLL.Infrastructure;
using ProcessManagement.BLL.Services.Interfaces;
using ProcessManagement.BLL.Validators.Users;
using ProcessManagement.Common.Enumerations;
using ProcessManagement.Common.Helpers;
using ProcessManagement.Common.Models.Inputs.Teams;
using ProcessManagement.Common.Models.Inputs.Users;
using ProcessManagement.DAL.Infrastructure;
using ProcessManagement.DTOs.Models;
using ProcessManagement.Entities.Models;
using ProcessManagement.Mappers.Infrastructure;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessManagement.BLL.Services.Implementations
{
    public class UserService : Service, IUserService
    {
        public UserService(ProcessManagementDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<UserDTO> CreateAsync(CreateUserInput createUserInput)
        {
            var user = createUserInput.MapTo<User>();

            var validator = new CreateUserValidator(DbContext);
            await validator.ValidateAsync(user);

            await DbContext.Users.AddAsync(user);
            await DbContext.SaveChangesAsync();

            return user.MapTo<UserDTO>();
        }

        public async Task<UserDTO> AddToTeamAsync(AddUserToTeamInput updateTeamInput)
        {
            var user = await DbContext.Users.FirstOrDefaultAsync(a => a.Id == updateTeamInput.UserId);

            user.TeamId = updateTeamInput.TeamId;

            DbContext.Users.Update(user);
            await DbContext.SaveChangesAsync();

            return user.MapTo<UserDTO>();
        }

        public async Task<UserDTO> DetachFromTeamAsync(int id)
        {
            var user = await DbContext.Users.FirstOrDefaultAsync(a => a.Id == id);

            if (user == default)
                ExceptionHelper.ThrowFaultException("User not found", StatusCodes.Status400BadRequest);

            user.TeamId = null;

            DbContext.Update(user);
            await DbContext.SaveChangesAsync();

            return user.MapTo<UserDTO>();
        }

        public async Task<UserDTO> GetByUsernameAsync(string username)
        {
            var user = await DbContext.Users.FirstOrDefaultAsync(m => m.Username == username);

            return user.MapTo<UserDTO>();
        }

        public async Task<bool> IsInTypeAsync(UserTypes[] requiredUserTypes, string username)
            => await DbContext.Users.AnyAsync(u => u.Username == username && requiredUserTypes.Contains(u.Type));
    }
}
