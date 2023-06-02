using TaskManager.Application.Contracts.Persistence;
using TaskManager.Domain;

namespace TaskManager.Persistence.Repositories
{
    public class TodoRepository : GenericRepository<Todo>, ITodoRepository
    {
        private readonly TaskManagerDbContext _dbContext;

        public TodoRepository(TaskManagerDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}