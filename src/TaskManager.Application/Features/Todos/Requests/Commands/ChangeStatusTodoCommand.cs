using MediatR;
using TaskManager.Application.DTOs.Todos;
using TaskManager.Application.Responses;

namespace TaskManager.Application.Features.Todos.Requests.Commands
{
    public class ChangeStatusTodoCommand : IRequest<BaseCommandResponse>
    {
        public ChangeStatusTodoDto ChangeStatusTodoDto { get; set; }
    }
}