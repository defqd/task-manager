using TaskManager.Domain;

namespace TaskManager.Application.Contracts.Persistence
{
    public interface ITodoListRepository : IGenericRepository<TodoList>
    {
    }
}