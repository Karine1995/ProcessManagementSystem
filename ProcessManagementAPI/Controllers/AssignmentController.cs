﻿using Microsoft.AspNetCore.Mvc;
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

        /// <summary>
        /// Get Assignment by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAssignment(int id)
        {
            var result  = await ServiceFactory.AssignmentService.GetByIdAsync(id);

            return Ok(result);
        }

        /// <summary>
        /// Update Assignment
        /// </summary>
        /// <param name="updateAssignmentInput"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> UpdateAssignmentStatus(UpdateAssignmentInput updateAssignmentInput)
        {
            await ServiceFactory.AssignmentService.UpdateAsync(updateAssignmentInput);

            return Ok("Assignment has been successfully updated");
        }
    }
}
