using ProcessManagement.Common.Enumerations;

namespace ProcessManagement.Common.Models.Inputs.Assignments
{
    public class UpdateAssignmentStatusInput
    {
        public int Id { get; set; }

        public AssignmentStatuses Status { get; set; }
    }
}
