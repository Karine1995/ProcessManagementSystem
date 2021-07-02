using ProcessManagement.BLL.Infrastructure;
using ProcessManagement.Common.Enumerations;
using ProcessManagement.Common.Models.Inputs.Teams;
using ProcessManagement.Common.Models.Inputs.Users;
using ProcessManagement.DTOs.Models;
using System.Threading.Tasks;

namespace ProcessManagement.BLL.Services.Interfaces
{
    public interface IUserService : IService
    {
        Task<UserDTO> CreateAsync(CreateUserInput createUserInput);

        Task<UserDTO> AddToTeamAsync(AddUserToTeamInput updateUserInput);

        Task<UserDTO> DetachFromTeamAsync(int id);

        Task<UserDTO> GetByUsernameAsync(string username);

        Task<bool> IsInTypeAsync(UserTypes[] requiredUserTypes, string username);
    }
}
