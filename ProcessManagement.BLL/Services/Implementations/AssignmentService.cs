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

namespace ProcessManagement.BLL.Services.Implementations
{
    public class AssignmentService : Service, IAssignmentService
    {
        public AssignmentService(ProcessManagementDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<AssignmentDTO> CreateAsync(CreateAssignmentInput createAssignmentInput)
        {
            var Assignment = createAssignmentInput.MapTo<Assignment>();
            Assignment.CreatedById = 21;
            var validator = new CreateAssignmentValidator(DbContext);
            await validator.ValidateAsync(Assignment);

            await DbContext.Assignments.AddAsync(Assignment);
            await DbContext.SaveChangesAsync();

            return Assignment.MapTo<AssignmentDTO>();
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
    }
}
