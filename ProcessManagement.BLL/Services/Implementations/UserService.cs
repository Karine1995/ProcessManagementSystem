using ProcessManagement.BLL.Infrastructure;
using ProcessManagement.BLL.Services.Interfaces;
using ProcessManagement.BLL.Validators.Users;
using ProcessManagement.Common.Models.Inputs.Users;
using ProcessManagement.DAL.Infrastructure;
using ProcessManagement.DTOs.Models;
using ProcessManagement.Entities.Models;
using ProcessManagement.Mappers.Infrastructure;
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
    }
}
