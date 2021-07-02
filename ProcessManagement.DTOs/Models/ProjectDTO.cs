using ProcessManagement.DTOs.Infrastructure;

namespace ProcessManagement.DTOs.Models
{
    public class ProjectDTO : BaseDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int UserId { get; set; }
    }
}
