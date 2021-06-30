using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProcessManagement.Common.Constants;
using ProcessManagement.Common.Helpers;
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
        [AllowAnonymous]
        public async Task<IActionResult> Register(CreateUserInput createUserInput)
        {
            using var transaction = TransactionHelper.CreateTransaction();

            await ServiceFactory.UserService.CreateAsync(createUserInput);
            await ServiceFactory.ProcessManagementIdentityService.RegisterUser(createUserInput);

            transaction.Complete();

            return Ok("You are successfully registered");
        }
    }
}
