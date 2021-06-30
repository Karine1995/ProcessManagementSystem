using ProcessManagement.Entities.Infrastructure;
using System.Collections.Generic;

namespace ProcessManagement.Entities.Models
{
    public class Team : BaseEntity
    {
        public Team()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
