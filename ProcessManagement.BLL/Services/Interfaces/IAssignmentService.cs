using ProcessManagement.BLL.Infrastructure;
using ProcessManagement.Common.Models.Inputs.Assignments;
using ProcessManagement.DTOs.Models;
using System.Threading.Tasks;

namespace ProcessManagement.BLL.Services.Interfaces
{
    public interface IAssignmentService : IService
    {
        Task<AssignmentDTO> CreateAsync(CreateAssignmentInput createAssignmentInput, string username);

        Task<AssignmentDTO> GetByIdAsync(int id);

        Task<AssignmentDTO> UpdateStatusAsync(UpdateAssignmentStatusInput updateAssignmentInput);

        Task<AssignmentDTO> DeleteAsync(int id);
    }
}
