using ProcessManagement.DTOs.Infrastructure;

namespace ProcessManagement.DTOs.Models
{
    public class TeamDTO : BaseDTO
    {
        public long Id { get; set; }

        public string Name { get; set; }
    }
}
