using Entities.Data;
using Microsoft.EntityFrameworkCore;
using Repositories.BoardRepository;
using Repositories.PriorityRepository;
using Repositories.RepositoryManager;
using Repositories.StatusRepository;
using Repositories.TaskChecklistRepository;
using Repositories.TaskRepository;

namespace TasklyAPI.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddDatabaseConnection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TasklyDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("TasklyDatanbase"), 
            b => b.MigrationsAssembly("TasklyAPI")));
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<IBoardRepository, BoardRepository>();
            services.AddScoped<ITaskChecklistRepository, TaskChecklistRepository>();
            services.AddScoped<IStatusRepository, StatusRepository>();
            services.AddScoped<IPriorityRepository, PriorityRepository>();

            services.AddScoped<IRepositoryManager, RepositoryManager>();
        }
    }
}
