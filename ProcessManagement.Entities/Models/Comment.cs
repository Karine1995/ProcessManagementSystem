using ProcessManagement.Entities.Infrastructure;

namespace ProcessManagement.Entities.Models
{
    public class Comment : BaseEntity
    {
        public long Id { get; set; }

        public string Content { get; set; }

        public int UserId { get; set; }

        public long AssignmentId { get; set; }

        public virtual User User { get; set; }

        public virtual Assignment Assignment { get; set; }
    }
}
