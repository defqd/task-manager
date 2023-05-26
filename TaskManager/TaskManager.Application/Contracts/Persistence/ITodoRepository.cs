using TaskManager.Domain;

namespace TaskManager.Application.Contracts.Persistence
{
    public interface ITodoRepository : IGenericRepository<Todo>
    {
    }
}