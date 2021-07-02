using Microsoft.AspNetCore.Mvc;
using ProcessManagement.Common.Constants;
using ProcessManagement.Common.Enumerations;
using ProcessManagement.Common.Models.Inputs.Assignments;
using ProcessManagement.Mappers.Infrastructure;
using ProcessManagement.ViewModels.Models.Assignments;
using ProcessManagementAPI.ActionFilters;
using ProcessManagementAPI.Infrastructure;
using System.Linq;
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
        [RequiredUserType(UserTypes.ProjectManager)]
        public async Task<IActionResult> Create(CreateAssignmentInput createAssignmentInput)
        {
            var username = User.Claims.FirstOrDefault(u => u.Type == Claims.Username).Value;
            await ServiceFactory.AssignmentService.CreateAsync(createAssignmentInput, username);

            return Ok("Assignment has been successfully created");
        }

        /// <summary>
        /// Get Assignment by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAssignment(int id)
        {
            var result = await ServiceFactory.AssignmentService.GetByIdAsync(id);

            return Ok(result.MapTo<AssignmentVM>());
        }

        /// <summary>
        /// Update Assignment
        /// </summary>
        /// <param name="updateAssignmentInput"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateAssignmentStatus(UpdateAssignmentStatusInput updateAssignmentInput)
        {
            await ServiceFactory.AssignmentService.UpdateStatusAsync(updateAssignmentInput);

            return Ok("Assignment status has been successfully updated");
        }

        /// <summary>
        /// Delete Assignment
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [RequiredUserType(UserTypes.ProjectManager)]
        public async Task<IActionResult> DeleteAssignment(int id)
        {
            await ServiceFactory.AssignmentService.DeleteAsync(id);

            return Ok("Assignment has been successfully deleted");
        }
    }
}
