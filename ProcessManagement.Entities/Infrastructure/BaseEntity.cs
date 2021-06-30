using System;

namespace ProcessManagement.Entities.Infrastructure
{
    public class BaseEntity
    {
        public DateTime CreationDate { get; set; }

        public DateTime LastUpdateTime { get; set; }
    }
}
