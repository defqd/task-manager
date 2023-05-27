using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskManager.Application.Contracts.Persistence;
using TaskManager.Persistence.Repositories;

namespace TaskManager.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TaskManagerDbContext>(options =>
               options.UseSqlServer(
                   configuration.GetConnectionString("TaskManagerConnectionString")));


            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<ITodoRepository, TodoRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();

            return services;
        }
    }
}
