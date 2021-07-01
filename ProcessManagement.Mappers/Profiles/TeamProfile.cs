using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProcessManagement.Common.Models.Inputs.Assignments;
using ProcessManagement.DTOs.Models;
using ProcessManagement.Entities.Models;
using ProcessManagement.Common.Models.Inputs.Teams;

namespace ProcessManagement.Mappers.Profiles
{
    internal class TeamProfile : Profile
    {
        public TeamProfile()
        {
            CreateMap<CreateTeamInput, Team>();

            CreateMap<Team, TeamDTO>();
        }
    }
}
