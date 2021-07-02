using AutoMapper;
using ProcessManagement.Common.Models.Inputs.Assignments;
using ProcessManagement.DTOs.Models;
using ProcessManagement.Entities.Models;

namespace ProcessManagement.Mappers.Profiles
{
    internal class AssignmentProfile : Profile
    {
        public AssignmentProfile()
        {
            CreateMap<CreateAssignmentInput, Assignment>();

            CreateMap<Assignment, AssignmentDTO>().ReverseMap();

            CreateMap<UpdateAssignmentStatusInput, Assignment>();
        }
    }
}
