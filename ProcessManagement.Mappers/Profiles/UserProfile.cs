using AutoMapper;
using ProcessManagement.Common.Models.Inputs.Users;
using ProcessManagement.DTOs.Models;
using ProcessManagement.Entities.Models;

namespace ProcessManagement.Mappers.Profiles
{
    internal class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserInput, User>();

            CreateMap<User, UserDTO>();
        }
    }
}
