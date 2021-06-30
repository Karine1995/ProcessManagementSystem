using ProcessManagement.Common.Enumerations;
using ProcessManagement.Entities.Infrastructure;
using System.Collections.Generic;

namespace ProcessManagement.Entities.Models
{
    public class Assignment : BaseEntity
    {
        public long Id { get; set; }

        public AssignmentStatuses Status { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int CreatedById { get; set; }

        public int AssigneeId { get; set; }

        public int ProjectId { get; set; }

        public virtual User CreatedByUser { get; set; }

        public virtual User Assignee { get; set; }

        public virtual Project Project { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
