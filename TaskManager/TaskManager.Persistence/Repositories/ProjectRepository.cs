using TaskManager.Application.Contracts.Persistence;
using TaskManager.Domain;

namespace TaskManager.Persistence.Repositories
{
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        private readonly TaskManagerDbContext _dbContext;

        public ProjectRepository(TaskManagerDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}