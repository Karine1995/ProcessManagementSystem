using ProcessManagement.Common.Models.Inputs.Users;
using System.Threading.Tasks;

namespace ProcessManagement.BLL.Infrastructure
{
    public interface IIdentityService
    {
        Task<int> RegisterUser(CreateUserInput createUserInput);
    }
}
