using MediatR;
using TaskManager.Application.DTOs.Todos;
using TaskManager.Application.Responses;

namespace TaskManager.Application.Features.Todos.Requests.Commands
{
    public class CreateTodoCommand : IRequest<BaseCommandResponse>
    {
        public CreateTodoDto CreateTodoDto { get; set; }
    }
}