using MediatR;
using TaskManager.Application.Responses;

namespace TaskManager.Application.Features.Todos.Requests.Commands
{
    public class DeleteTodoCommand : IRequest<BaseCommandResponse>
    {
        public int Id { get; set; }
    }
}