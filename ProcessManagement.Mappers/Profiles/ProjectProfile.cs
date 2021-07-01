using AutoMapper;
using ProcessManagement.Common.Models.Inputs.Projects;
using ProcessManagement.DTOs.Models;
using ProcessManagement.Entities.Models;

namespace ProcessManagement.Mappers.Profiles
{
    internal class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<CreateProjectInput, Project>();

            CreateMap<Project, ProjectDTO>();
        }
    }
}
