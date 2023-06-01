using MediatR;
using TaskManager.Application.DTOs.Projects;
using TaskManager.Application.Responses;

namespace TaskManager.Application.Features.Projects.Requests.Commands
{
    public class CreateProjectCommand : IRequest<BaseCommandResponse>
    {
        public CreateProjectDto CreateProjectDto { get; set; }
    }
}