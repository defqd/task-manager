using MediatR;
using TaskManager.Application.DTOs.Todos;

namespace TaskManager.Application.Features.Todos.Requests.Commands
{
    public class UpdateTodoCommand : IRequest<Unit>
    {
        public UpdateTodoDto UpdateTodoDto { get; set; }
    }
}