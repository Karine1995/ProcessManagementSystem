using ProcessManagement.BLL.Infrastructure;
using ProcessManagement.BLL.Services.Interfaces;
using ProcessManagement.BLL.Validators.Users;
using ProcessManagement.Common.Models.Inputs.Assignments;
using ProcessManagement.DAL.Infrastructure;
using ProcessManagement.DTOs.Models;
using ProcessManagement.Mappers.Infrastructure;
using System.Threading.Tasks;
using ProcessManagement.Entities.Models;
using Microsoft.EntityFrameworkCore;
using ProcessManagement.Common.Helpers;
using Microsoft.AspNetCore.Http;

namespace ProcessManagement.BLL.Services.Implementations
{
    public class AssignmentService : Service, IAssignmentService
    {
        public AssignmentService(ProcessManagementDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<AssignmentDTO> CreateAsync(CreateAssignmentInput createAssignmentInput, string username)
        {
            var assignment = createAssignmentInput.MapTo<Assignment>();

            assignment.CreatedById = await GetUserIdByName(username);

            var validator = new CreateAssignmentValidator(DbContext);
            await validator.ValidateAsync(assignment);

            await DbContext.Assignments.AddAsync(assignment);
            await DbContext.SaveChangesAsync();

            return assignment.MapTo<AssignmentDTO>();
        }

        public async Task<AssignmentDTO> GetByIdAsync(int id)
        {
            var assignment = await DbContext.Assignments.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);

            return assignment.MapTo<AssignmentDTO>();
        }

        public async Task<AssignmentDTO> UpdateStatusAsync(UpdateAssignmentStatusInput updateAssignmentInput)
        {
            var assignment = await DbContext.Assignments.FirstOrDefaultAsync(a => a.Id == updateAssignmentInput.Id);

            if (assignment == default)
                ExceptionHelper.ThrowFaultException("Assignment not found", StatusCodes.Status400BadRequest);

            assignment.Status = updateAssignmentInput.Status;

            DbContext.Update(assignment);
            await DbContext.SaveChangesAsync();

            return assignment.MapTo<AssignmentDTO>();
        }

        public async Task<AssignmentDTO> DeleteAsync(int id)
        {
            var assignment = await DbContext.Assignments.FirstOrDefaultAsync(a => a.Id == id);

            DbContext.Assignments.Remove(assignment);
            await DbContext.SaveChangesAsync();

            return assignment.MapTo<AssignmentDTO>();
        }
    }
}
