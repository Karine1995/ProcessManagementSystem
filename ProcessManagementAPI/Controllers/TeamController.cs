using Microsoft.AspNetCore.Mvc;
using ProcessManagement.Common.Constants;
using ProcessManagement.Common.Models.Inputs.Teams;
using ProcessManagementAPI.Infrastructure;
using System.Threading.Tasks;

namespace ProcessManagementAPI.Controllers
{
    /// <summary>
    /// </summary>
    [ApiVersion(Constants.ApiVersion1)]
    public class TeamController : BaseController
    {
        /// <summary>
        /// </summary>
        /// <param name="serviceFactory"></param>
        public TeamController(ServiceFactory serviceFactory) : base(serviceFactory)
        {
        }

        /// <summary>
        /// Add Team
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(string name)
        {
            await ServiceFactory.TeamService.CreateAsync(name);

            return Ok("Team has been successfully created");
        }
    }
}
