using Microsoft.EntityFrameworkCore;
using ProcessManagement.BLL.Infrastructure;
using ProcessManagement.BLL.Services.Interfaces;
using ProcessManagement.BLL.Validators.Users;
using ProcessManagement.Common.Models.Inputs.Teams;
using ProcessManagement.Common.Models.Inputs.Users;
using ProcessManagement.DAL.Infrastructure;
using ProcessManagement.DTOs.Models;
using ProcessManagement.Entities.Models;
using ProcessManagement.Mappers.Infrastructure;
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

        public async Task<UserDTO> UpdateAsync(UpdateUserInput updateTeamInput)
        {
            var user = updateTeamInput.MapTo<User>();
            //var validator = new UpdateUserValidator(DbContext);
            //await validator.ValidateAsync(user);

            user = DbContext.Users.First(a => a.Id == updateTeamInput.UserId);
            user.TeamId = updateTeamInput.TeamId;
            await DbContext.SaveChangesAsync();

            return user.MapTo<UserDTO>();
        }

        public async Task<UserDTO> DeleteAsync(DeleteUserInput deleteTeamInput)
        {
            var user = deleteTeamInput.MapTo<User>();
            var validator = new DeleteUserValidator(DbContext);
            await validator.ValidateAsync(user);

            user = DbContext.Users.First(a => a.Id == deleteTeamInput.UserId);
            user.TeamId = null;
            await DbContext.SaveChangesAsync();

            return user.MapTo<UserDTO>();
        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            var user = await DbContext.Users.FirstOrDefaultAsync(m => m.Username == username);

            return user;
        }
    }
}
