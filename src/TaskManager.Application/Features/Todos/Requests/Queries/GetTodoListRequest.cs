using MediatR;
using TaskManager.Application.DTOs.Todos;

namespace TaskManager.Application.Features.Todos.Requests.Queries
{
    public class GetTodoListRequest : IRequest<List<TodoDto>>
    {
    }
}