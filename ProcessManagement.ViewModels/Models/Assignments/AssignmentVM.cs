using ProcessManagement.ViewModels.Infrastructure;

namespace ProcessManagement.ViewModels.Models.Assignments
{
    public class AssignmentVM : BaseViewModel
    {
        public long Id { get; set; }

        public short Status { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int CreatedById { get; set; }

        public int AssigneeId { get; set; }

        public int ProjectId { get; set; }
    }
}
