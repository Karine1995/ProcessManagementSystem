using ProcessManagement.BLL.Infrastructure;
using ProcessManagement.DTOs.Models;
using System.Threading.Tasks;

namespace ProcessManagement.BLL.Services.Interfaces
{
    public interface ITeamService : IService
    {
        Task<TeamDTO> CreateAsync(string team);
    }
}
