using ProcessManagement.Common.Enumerations;
using ProcessManagement.Entities.Infrastructure;
using System.Collections.Generic;

namespace ProcessManagement.Entities.Models
{
    public class User : BaseEntity
    {
        public User()
        {
            CreatedAssignments = new HashSet<Assignment>();
            Assignments = new HashSet<Assignment>();
            Comments = new HashSet<Comment>();
            Projects = new HashSet<Project>();
        }

        public int Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public UserTypes Type { get; set; }

        public int? TeamId { get; set; }

        public virtual Team Team { get; set; }

        public virtual ICollection<Assignment> CreatedAssignments { get; set; }

        public virtual ICollection<Assignment> Assignments { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}
