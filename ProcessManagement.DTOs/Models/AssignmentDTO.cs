using ProcessManagement.DTOs.Infrastructure;

namespace ProcessManagement.DTOs.Models
{
    public class AssignmentDTO : BaseDTO
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
