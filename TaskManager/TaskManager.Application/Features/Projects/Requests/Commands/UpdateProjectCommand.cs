using MediatR;
using TaskManager.Application.DTOs.Projects;
using TaskManager.Application.Responses;

namespace TaskManager.Application.Features.Projects.Requests.Commands
{
    public class UpdateProjectCommand : IRequest<BaseCommandResponse>
    {
        public UpdateProjectDto UpdateProjectDto { get; set; }
    }
}