using ProcessManagement.Common.Enumerations;

namespace ProcessManagement.Common.Models.Inputs.Users
{
    public class CreateUserInput
    {
        public string Username { get; set; }

        public UserTypes Type { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
