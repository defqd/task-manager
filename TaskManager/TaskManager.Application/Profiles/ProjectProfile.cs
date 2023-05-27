using AutoMapper;
using TaskManager.Application.DTOs.Projects;
using TaskManager.Domain;

namespace TaskManager.Application.Profiles
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<Project, ProjectDto>().ReverseMap();
            CreateMap<CreateProjectDto, Project>();
            CreateMap<UpdateProjectDto, Project>();
        }
    }
}