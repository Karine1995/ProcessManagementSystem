using ProcessManagement.BLL.Infrastructure;
using ProcessManagement.BLL.Services.Interfaces;
using ProcessManagement.BLL.Validators.Users;
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

        public async Task<ProjectDTO> CreateAsync(CreateProjectInput createProjectInput)
        {
            var project = createProjectInput.MapTo<Project>();
            project.UserId = 21;
            var validator = new CreateProjectValidator(DbContext);
            await validator.ValidateAsync(project);

            await DbContext.Projects.AddAsync(project);
            await DbContext.SaveChangesAsync();

            return project.MapTo<ProjectDTO>();
        }
    }
}
