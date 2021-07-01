using ProcessManagement.BLL.Infrastructure;
using ProcessManagement.Common.Models.Inputs.Teams;
using ProcessManagement.Common.Models.Inputs.Users;
using ProcessManagement.DTOs.Models;
using System.Threading.Tasks;

namespace ProcessManagement.BLL.Services.Interfaces
{
    public interface IUserService : IService
    {
        Task<UserDTO> CreateAsync(CreateUserInput createUserInput);

        Task<UserDTO> UpdateAsync(UpdateUserInput updateUserInput);

        Task<UserDTO> DeleteAsync(DeleteUserInput deeleteUserInput);
    }
}
