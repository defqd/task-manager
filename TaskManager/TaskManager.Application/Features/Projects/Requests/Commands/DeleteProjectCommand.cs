using MediatR;
using TaskManager.Application.Responses;

namespace TaskManager.Application.Features.Projects.Requests.Commands
{
    public class DeleteProjectCommand : IRequest<BaseCommandResponse>
    {
        public int Id { get; set; }
    }
}