using ProcessManagement.Entities.Infrastructure;
using System.Collections.Generic;

namespace ProcessManagement.Entities.Models
{
    public class Project : BaseEntity
    {
        public Project()
        {
            Assignments = new HashSet<Assignment>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public virtual  ICollection<Assignment> Assignments { get; set; }
    }
}
