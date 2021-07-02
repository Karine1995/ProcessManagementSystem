using ProcessManagement.BLL.Infrastructure;
using ProcessManagement.BLL.Services.Interfaces;
using ProcessManagement.BLL.Validators.Users;
using ProcessManagement.Common.Models.Inputs.Assignments;
using ProcessManagement.DAL.Infrastructure;
using ProcessManagement.DTOs.Models;
using ProcessManagement.Mappers.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProcessManagement.Entities.Models;
using Microsoft.EntityFrameworkCore;
using ProcessManagement.Common.Enumerations;
using ProcessManagement.BLL.Validators.Assignments;

namespace ProcessManagement.BLL.Services.Implementations
{
    public class AssignmentService : Service, IAssignmentService
    {
        public AssignmentService(ProcessManagementDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<AssignmentDTO> CreateAsync(CreateAssignmentInput createAssignmentInput, User user)
        {
            var assignment = createAssignmentInput.MapTo<Assignment>();
            assignment.CreatedById = user.Id;
            assignment.CreatedByUser = user;
            var validator = new CreateAssignmentValidator(DbContext);
            await validator.ValidateAsync(assignment);

            await DbContext.Assignments.AddAsync(assignment);
            await DbContext.SaveChangesAsync();

            return assignment.MapTo<AssignmentDTO>();
        }

        public async Task<AssignmentDTO> GetByIdAsync(int id)
        {
            var assignment = await DbContext.Assignments.FirstOrDefaultAsync(m => m.Id == id);           

            return assignment.MapTo<AssignmentDTO>();
        }

        public async Task<AssignmentDTO> UpdateAsync(UpdateAssignmentInput updateAssignmentInput)
        {
            var user = updateAssignmentInput.MapTo<Assignment>();
            //var validator = new UpdateUserValidator(DbContext);
            //await validator.ValidateAsync(user);

            user = DbContext.Assignments.First(a => a.Id == updateAssignmentInput.Id);
            user.Status = (AssignmentStatuses)updateAssignmentInput.Status;
            await DbContext.SaveChangesAsync();

            return user.MapTo<AssignmentDTO>();
        }

        public async Task<AssignmentDTO> DeleteAsync(DeleteAssignmentInput deleteAssignmentInput, User user)
        {
            var assignment = deleteAssignmentInput.MapTo<Assignment>();
            assignment = DbContext.Assignments.First(a => a.Id == deleteAssignmentInput.Id);
            assignment.CreatedById = user.Id;
            assignment.CreatedByUser = user;
            var validator = new DeleteAssignmentValidator(DbContext);
            await validator.ValidateAsync(assignment);

            DbContext.Assignments.Remove(assignment);
            await DbContext.SaveChangesAsync();

            return assignment.MapTo<AssignmentDTO>();
        }
    }
}
