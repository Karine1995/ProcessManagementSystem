using ProcessManagement.BLL.Infrastructure;
using ProcessManagement.Common.Models.Inputs.Projects;
using ProcessManagement.DTOs.Models;
using System.Threading.Tasks;

namespace ProcessManagement.BLL.Services.Interfaces
{
    public interface IProjectService : IService
    {
        Task<ProjectDTO> CreateAsync(CreateProjectInput createProjectInput);

        Task<ProjectDTO> GetByIdAsync(int id);
    }
}
