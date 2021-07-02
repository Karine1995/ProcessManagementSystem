using Microsoft.EntityFrameworkCore;
using ProcessManagement.BLL.Infrastructure;
using ProcessManagement.BLL.Services.Interfaces;
using ProcessManagement.Common.Models.Inputs.Projects;
using ProcessManagement.DAL.Infrastructure;
using ProcessManagement.DTOs.Models;
using ProcessManagement.Entities.Models;
using ProcessManagement.Mappers.Infrastructure;
using System.Threading.Tasks;

namespace ProcessManagement.BLL.Services.Implementations
{
    public class ProjectService : Service, IProjectService
    {
        public ProjectService(ProcessManagementDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<ProjectDTO> CreateAsync(CreateProjectInput createProjectInput, string username)
        {
            var project = createProjectInput.MapTo<Project>();
            project.UserId = await GetUserIdByName(username);

            await DbContext.Projects.AddAsync(project);
            await DbContext.SaveChangesAsync();

            return project.MapTo<ProjectDTO>();
        }

        public async Task<ProjectDTO> GetByIdAsync(int id)
        {
            var project = await DbContext.Projects.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);

            return project.MapTo<ProjectDTO>();
        }

        public async Task<ProjectDTO> DeleteAsync(int id)
        {
            var project = await DbContext.Projects.FirstOrDefaultAsync(p => p.Id == id);

            DbContext.Projects.Remove(project);
            await DbContext.SaveChangesAsync();

            return project.MapTo<ProjectDTO>();
        }
    }
}