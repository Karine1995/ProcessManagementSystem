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
        /// <param name="createTeamInput"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddTeam(CreateTeamInput createTeamInput)
        {
            await ServiceFactory.TeamService.CreateAsync(createTeamInput);

            return Ok("Team has been successfully created");
        }
    }
}
