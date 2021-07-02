using AutoMapper;
using ProcessManagement.DTOs.Models;
using ProcessManagement.Entities.Models;

namespace ProcessManagement.Mappers.Profiles
{
    internal class TeamProfile : Profile
    {
        public TeamProfile()
        {
            CreateMap<Team, TeamDTO>().ReverseMap();
        }
    }
}
