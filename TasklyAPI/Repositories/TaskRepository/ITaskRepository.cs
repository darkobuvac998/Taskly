using Repositories.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.TaskRepository
{
    public interface ITaskRepository : IBaseRepository<Entities.Models.Task>
    {
        bool TaskExists(Expression<Func<Entities.Models.Task, bool>> predicate);
        Task<bool> TaskExistsAsync(Expression<Func<Entities.Models.Task, bool>> predicate);
    }
}
