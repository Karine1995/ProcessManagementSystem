using Microsoft.AspNetCore.Mvc;
using ProcessManagement.Common.Constants;
using ProcessManagement.Common.Enumerations;
using ProcessManagement.Common.Helpers;
using ProcessManagement.Common.Models.Inputs.Teams;
using ProcessManagement.Common.Models.Inputs.Users;
using ProcessManagementAPI.ActionFilters;
using ProcessManagementAPI.Infrastructure;
using System.Threading.Tasks;

namespace ProcessManagementAPI.Controllers
{
    /// <summary>
    /// </summary>
    [ApiVersion(Constants.ApiVersion1)]
    public class UserController : BaseController
    {
        /// <summary>
        /// </summary>
        /// <param name="serviceFactory"></param>
        public UserController(ServiceFactory serviceFactory) : base(serviceFactory)
        {
        }

        /// <summary>
        /// Register user
        /// </summary>
        /// <param name="createUserInput"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Register(CreateUserInput createUserInput)
        {
            using var transaction = TransactionHelper.CreateTransaction();

            await ServiceFactory.UserService.CreateAsync(createUserInput);
            await ServiceFactory.ProcessManagementIdentityService.RegisterUserAsync(createUserInput);

            transaction.Complete();

            return Ok("You are successfully registered");
        }

        /// <summary>
        /// Add user to team
        /// </summary>
        /// <param name="updateUserInput"></param>
        /// <returns></returns>
        [HttpPost]
        [RequiredUserType(UserTypes.ProjectManager)]
        public async Task<IActionResult> AddToTeam(AddUserToTeamInput updateUserInput)
        {
            await ServiceFactory.UserService.AddToTeamAsync(updateUserInput);

            return Ok("User successfully attached to team");
        }

        /// <summary>
        /// Remove user from team
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [RequiredUserType(UserTypes.ProjectManager)]
        public async Task<IActionResult> DetachFromTeam(int id)
        {
            await ServiceFactory.UserService.DetachFromTeamAsync(id);

            return Ok("User successfully removed from team");
        }

        /// <summary>
        /// Get User by username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetByUsername(string username)
        {
            var result = await ServiceFactory.UserService.GetByUsernameAsync(username);

            return Ok(result);
        }
    }
}
