using Entities.Data;
using Entities.Models;
using Repositories.BaseRepository;

namespace Repositories.PriorityRepository
{
    public class PriorityRepository : BaseRepository<Priority>, IPriorityRepository
    {
        public PriorityRepository(TasklyDbContext context) : base(context)
        {
        }
    }
}
