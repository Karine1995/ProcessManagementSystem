using Microsoft.EntityFrameworkCore;
using ProcessManagement.BLL.Infrastructure;
using ProcessManagement.BLL.Services.Interfaces;
using ProcessManagement.BLL.Validators.Projects;
using ProcessManagement.BLL.Validators.Users;
using ProcessManagement.Common.Models.Inputs.Projects;
using ProcessManagement.DAL.Infrastructure;
using ProcessManagement.DTOs.Models;
using ProcessManagement.Entities.Models;
using ProcessManagement.Mappers.Infrastructure;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessManagement.BLL.Services.Implementations
{
    public class ProjectService : Service, IProjectService
    {
        public ProjectService(ProcessManagementDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<ProjectDTO> CreateAsync(CreateProjectInput createProjectInput, User user)
        {
            var project = createProjectInput.MapTo<Project>();
            project.UserId = user.Id;
            project.User = user;
            var validator = new CreateProjectValidator(DbContext);
            await validator.ValidateAsync(project);

            await DbContext.Projects.AddAsync(project);
            await DbContext.SaveChangesAsync();

            return project.MapTo<ProjectDTO>();
        }

        public Project GetByIdAsync(int id)
        {
            var project = DbContext.Projects.Where(m => m.Id == id)
                                            .Include(m => m.Assignments)
                                            .FirstOrDefault();
            //var assignments = await DbContext.Assignments.FirstOrDefaultAsync(m => m.ProjectId == id);
            //project.Assignments.MapTo<AssignmentDTO>();
            return project;
        }

        public async Task<ProjectDTO> DeleteAsync(DeleteProjectInput deleteProjectInput, User user)
        {
            var project = deleteProjectInput.MapTo<Project>();
            project.UserId = user.Id;
            project.User = user;
            var validator = new DeleteProjectValidator(DbContext);
            await validator.ValidateAsync(project);

            DbContext.Projects.Remove(project);
            await DbContext.SaveChangesAsync();

            return project.MapTo<ProjectDTO>();
        }
    }
}