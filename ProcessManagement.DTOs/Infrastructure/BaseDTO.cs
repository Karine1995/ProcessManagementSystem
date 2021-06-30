using System;

namespace ProcessManagement.DTOs.Infrastructure
{
    public class BaseDTO
    {
        public DateTime CreationDate { get; set; }

        public DateTime LastUpdateTime { get; set; }
    }
}
