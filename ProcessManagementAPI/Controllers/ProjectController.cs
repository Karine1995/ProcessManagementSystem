using Microsoft.AspNetCore.Mvc;
using ProcessManagement.Common.Constants;
using ProcessManagement.Common.Enumerations;
using ProcessManagement.Common.Models.Inputs.Projects;
using ProcessManagementAPI.ActionFilters;
using ProcessManagementAPI.Infrastructure;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessManagementAPI.Controllers
{
    /// <summary>
    /// </summary>
    [ApiVersion(Constants.ApiVersion1)]
    public class ProjectController :BaseController
    {
        /// <summary>
        /// </summary>
        /// <param name="serviceFactory"></param>
        public ProjectController(ServiceFactory serviceFactory) : base(serviceFactory)
        {
        }

        /// <summary>
        /// Add Project
        /// </summary>
        /// <param name="createProjectInput"></param>
        /// <returns></returns>
        [HttpPost]
        [RequiredUserType(UserTypes.ProjectManager)]
        public async Task<IActionResult> Create(CreateProjectInput createProjectInput)
        {
            var username = User.Claims.FirstOrDefault(u => u.Type == Claims.Username).Value;
            await ServiceFactory.ProjectService.CreateAsync(createProjectInput, username);

            return Ok("Project successfully added");
        }

        /// <summary>
        /// Get Project by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await ServiceFactory.ProjectService.GetByIdAsync(id);

            return Ok(result);
        }

        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [RequiredUserType(UserTypes.ProjectManager)]
        public async Task<IActionResult> Delete(int id)
        {
            await ServiceFactory.ProjectService.DeleteAsync(id);

            return Ok("Project successfully deleted");
        }
    }
}
