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
    public class TaskController :BaseController
    {
        /// <summary>
        /// </summary>
        /// <param name="serviceFactory"></param>
        public TaskController(ServiceFactory serviceFactory) : base(serviceFactory)
        {
        }

        /// <summary>
        /// Register user
        /// </summary>
        /// <param name="createUserInput"></param>
        /// <returns></returns>
        //[HttpPost]
        //[AllowAnonymous]
        //public async Task<IActionResult> AddTask(CreateTaskInput createTaskInput)
        //{
        //    using var transaction = TransactionHelper.CreateTransaction();

        //    await ServiceFactory.TaskService.CreateAsync(createUserInput);

        //    transaction.Complete();

        //    return Ok("You are successfully add task");
        //}
    }
}
