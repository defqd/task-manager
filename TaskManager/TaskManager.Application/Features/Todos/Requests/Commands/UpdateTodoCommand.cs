using MediatR;
using TaskManager.Application.DTOs.Todos;
using TaskManager.Application.Responses;

namespace TaskManager.Application.Features.Todos.Requests.Commands
{
    public class UpdateTodoCommand : IRequest<BaseCommandResponse>
    {
        public UpdateTodoDto UpdateTodoDto { get; set; }
    }
}