using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProcessManagement.Common.Constants;
using ProcessManagement.Common.Models.Inputs.Projects;
using ProcessManagementAPI.Infrastructure;
using System.Linq;
using System.Security.Claims;
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
        public async Task<IActionResult> Register(CreateProjectInput createProjectInput)
        {
            //var a = User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.Name);
            //var user = HttpContext.User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier).Value;
            var user = User.Claims.FirstOrDefault(u => u.Type == Claims.Username).Value;
            var userInfo = await ServiceFactory.UserService.GetByUsernameAsync(user);
            await ServiceFactory.ProjectService.CreateAsync(createProjectInput, userInfo);

            return Ok("Project successfully added");
        }

        /// <summary>
        /// Get Project by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetProject(int id)
        {
            var result = ServiceFactory.ProjectService.GetByIdAsync(id);

            return Ok(result);
        }
    }
}
