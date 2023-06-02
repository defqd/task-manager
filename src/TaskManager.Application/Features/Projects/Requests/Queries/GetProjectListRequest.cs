using MediatR;
using TaskManager.Application.DTOs.Projects;

namespace TaskManager.Application.Features.Projects.Requests.Queries
{
    public class GetProjectListRequest : IRequest<List<ProjectDto>>
    {
    }
}