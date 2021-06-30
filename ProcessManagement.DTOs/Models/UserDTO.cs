using ProcessManagement.Common.Enumerations;
using ProcessManagement.DTOs.Infrastructure;

namespace ProcessManagement.DTOs.Models
{
    public class UserDTO : BaseDTO
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public UserTypes Type { get; set; }

        public int? TeamId { get; set; }
    }
}
