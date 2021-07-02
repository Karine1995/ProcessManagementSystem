using ProcessManagement.BLL.Infrastructure;
using ProcessManagement.Common.Models.Inputs.Assignments;
using ProcessManagement.DTOs.Models;
using ProcessManagement.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessManagement.BLL.Services.Interfaces
{
    public interface IAssignmentService : IService
    {
        Task<AssignmentDTO> CreateAsync(CreateAssignmentInput createAssignmentInput, User user);

        Task<AssignmentDTO> GetByIdAsync(int id);

        Task<AssignmentDTO> UpdateAsync(UpdateAssignmentInput updateAssignmentInput);

        Task<AssignmentDTO> DeleteAsync(DeleteAssignmentInput deleteAssignmentInput, User user);
    }
}
