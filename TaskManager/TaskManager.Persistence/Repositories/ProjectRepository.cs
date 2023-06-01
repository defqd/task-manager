using Microsoft.EntityFrameworkCore;
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

        public async Task<Project> GetProjectWithDetails(int id)
        {
            var project = await _dbContext.Projects
                .Include(q => q.Todo)
                .FirstOrDefaultAsync(q => q.Id == id);

            return project;
        }

        public async Task<List<Project>> GetProjectsWithDetails()
        {
            var projects = await _dbContext.Projects
                .Include(q => q.Todo)
                .ToListAsync();

            return projects;
        }
    }
}