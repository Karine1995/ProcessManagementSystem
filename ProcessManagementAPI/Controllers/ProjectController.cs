using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProcessManagement.Common.Constants;
using ProcessManagement.Common.Models.Inputs.Projects;
using ProcessManagementAPI.Infrastructure;
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
        /// Register user
        /// </summary>
        /// <param name="createProjectInput"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Register(CreateProjectInput createProjectInput)
        {
            await ServiceFactory.ProjectService.CreateAsync(createProjectInput);

            return Ok("Project successfully added");
        }
    }
}
