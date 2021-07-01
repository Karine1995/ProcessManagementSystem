using ProcessManagement.DTOs.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
