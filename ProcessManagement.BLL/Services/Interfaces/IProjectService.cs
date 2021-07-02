using ProcessManagement.BLL.Infrastructure;
using ProcessManagement.Common.Models.Inputs.Projects;
using ProcessManagement.DTOs.Models;
using ProcessManagement.Entities.Models;
using System.Threading.Tasks;

namespace ProcessManagement.BLL.Services.Interfaces
{
    public interface IProjectService : IService
    {
        Task<ProjectDTO> CreateAsync(CreateProjectInput createProjectInput, User userId);

        Task<ProjectDTO> GetByIdAsync(int id);
    }
}
