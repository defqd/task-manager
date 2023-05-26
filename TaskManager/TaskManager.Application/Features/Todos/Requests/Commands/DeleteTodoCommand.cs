using MediatR;

namespace TaskManager.Application.Features.Todos.Requests.Commands
{
    public class DeleteTodoCommand : IRequest
    {
        public int Id { get; set; }
    }
}