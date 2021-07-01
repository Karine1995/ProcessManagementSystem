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
    }
}
