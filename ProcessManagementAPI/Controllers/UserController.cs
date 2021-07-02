using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProcessManagement.Common.Constants;
using ProcessManagement.Common.Helpers;
using ProcessManagement.Common.Models.Inputs.Teams;
using ProcessManagement.Common.Models.Inputs.Users;
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
            await ServiceFactory.ProcessManagementIdentityService.RegisterUser(createUserInput);

            transaction.Complete();

            return Ok("You are successfully registered");
        }

        /// <summary>
        /// Update user team
        /// </summary>
        /// <param name="updateUserInput"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> UpdateAsync(UpdateUserInput updateUserInput)
        {

            await ServiceFactory.UserService.UpdateAsync(updateUserInput);

            return Ok("You are successfully updated");
        }

        /// <summary>
        /// Delete user team
        /// </summary>
        /// <param name="deleteUserInput"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> DeleteAsync(DeleteUserInput deleteUserInput)
        {

            await ServiceFactory.UserService.DeleteAsync(deleteUserInput);

            return Ok("You are successfully deleted team");
        }

        /// <summary>
        /// Get User Info by username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetByUsernameAsync(string username)
        {
            var result = await ServiceFactory.UserService.GetByUsernameAsync(username);

            return Ok(result);
        }
    }
}
