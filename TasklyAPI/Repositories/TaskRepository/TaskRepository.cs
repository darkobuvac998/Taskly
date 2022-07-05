using Entities.Data;
using Microsoft.EntityFrameworkCore;
using Repositories.BaseRepository;
using System.Linq.Expressions;

namespace Repositories.TaskRepository
{
    public class TaskRepository : BaseRepository<Entities.Models.Task>, ITaskRepository
    {
        public TaskRepository(TasklyDbContext context) : base(context)
        {
        }

        public bool TaskExists(Expression<Func<Entities.Models.Task, bool>> predicate)
        {
            return dbContext.Tasks.Any(predicate);
        }

        public Task<bool> TaskExistsAsync(Expression<Func<Entities.Models.Task, bool>> predicate)
        {
            return dbContext.Tasks.AnyAsync(predicate);
        }
    }
}
