using TaskManager.Domain;

namespace TaskManager.Application.Contracts.Persistence
{
    public interface IProjectRepository : IGenericRepository<Project>
    {
        Task<Project> GetProjectWithDetails(int id);
        Task<List<Project>> GetProjectsWithDetails();
    }
}