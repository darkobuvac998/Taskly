using Entities.Data;
using Entities.Models;
using Repositories.BaseRepository;

namespace Repositories.TaskChecklistRepository
{
    public class TaskChecklistRepository : BaseRepository<TaskChecklist>, ITaskChecklistRepository
    {
        public TaskChecklistRepository(TasklyDbContext context) : base(context)
        {
        }
    }
}
