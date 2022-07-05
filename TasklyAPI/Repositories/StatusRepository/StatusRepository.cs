using Entities.Data;
using Entities.Models;
using Repositories.BaseRepository;

namespace Repositories.StatusRepository
{
    public class StatusRepository : BaseRepository<Status>, IStatusRepository
    {
        public StatusRepository(TasklyDbContext context) : base(context)
        {
        }
    }
}
