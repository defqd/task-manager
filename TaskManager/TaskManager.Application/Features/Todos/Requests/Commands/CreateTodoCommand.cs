using MediatR;
using TaskManager.Application.DTOs.Todos;

namespace TaskManager.Application.Features.Todos.Requests.Commands
{
    public class CreateTodoCommand : IRequest<int>
    {
        public CreateTodoDto CreateTodoDto { get; set; }
    }
}