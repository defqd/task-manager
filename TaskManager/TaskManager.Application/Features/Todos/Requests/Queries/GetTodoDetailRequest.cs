using MediatR;
using TaskManager.Application.DTOs.Todos;

namespace TaskManager.Application.Features.Todos.Requests.Queries
{
    public class GetTodoDetailRequest : IRequest<TodoDto>
    {
        public int Id { get; set; }
    }
}