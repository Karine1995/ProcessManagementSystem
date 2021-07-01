namespace ProcessManagement.Common.Models.Inputs.Assignments
{
    public class CreateAssignmentInput
    {
        public int ProjectId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int AssigneeId { get; set; }
    }
}
