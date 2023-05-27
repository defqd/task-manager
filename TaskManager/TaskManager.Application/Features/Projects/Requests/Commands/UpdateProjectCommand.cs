using MediatR;
using TaskManager.Application.DTOs.Projects;

namespace TaskManager.Application.Features.Projects.Requests.Commands
{
    public class UpdateProjectCommand : IRequest<Unit>
    {
        public UpdateProjectDto UpdateProjectDto { get; set; }
    }
}