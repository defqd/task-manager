using Microsoft.EntityFrameworkCore;
using TaskManager.Domain;

namespace TaskManager.Persistence
{
    public class TaskManagerDbContext : DbContext
    {
        public TaskManagerDbContext(DbContextOptions<TaskManagerDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TaskManagerDbContext).Assembly);
        }

        public DbSet<Todo> Todos { get; set; }
        public DbSet<Project> Projects { get; set; }
    }
}