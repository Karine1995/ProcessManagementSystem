using Microsoft.AspNetCore.Mvc;
using ProcessManagement.Common.Constants;
using ProcessManagement.Common.Models.Inputs.Assignments;
using ProcessManagementAPI.Infrastructure;
using System.Threading.Tasks;

namespace ProcessManagementAPI.Controllers
{
    /// <summary>
    /// </summary>
    [ApiVersion(Constants.ApiVersion1)]
    public class AssignmentController :BaseController
    {
        /// <summary>
        /// </summary>
        /// <param name="serviceFactory"></param>
        public AssignmentController(ServiceFactory serviceFactory) : base(serviceFactory)
        {
        }

        /// <summary>
        /// Add Assignment
        /// </summary>
        /// <param name="createAssignmentInput"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddAssignment(CreateAssignmentInput createAssignmentInput)
        {
            await ServiceFactory.AssignmentService.CreateAsync(createAssignmentInput);

            return Ok("Assignment has been successfully created");
        }
    }
}
