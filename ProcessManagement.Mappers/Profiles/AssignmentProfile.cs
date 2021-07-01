using AutoMapper;
using ProcessManagement.Common.Models.Inputs.Assignments;
using ProcessManagement.DTOs.Models;
using ProcessManagement.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessManagement.Mappers.Profiles
{
    internal class AssignmentProfile : Profile
    {
        public AssignmentProfile()
        {
            CreateMap<CreateAssignmentInput, Assignment>();

            CreateMap<Assignment, AssignmentDTO>();
        }
    }
}
