using ProcessManagement.DTOs.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessManagement.DTOs.Models
{
    public class TeamDTO : BaseDTO
    {
        public long Id { get; set; }

        public string Name { get; set; }
    }
}
