using Entities.Data;
using Entities.Models;
using Repositories.BaseRepository;

namespace Repositories.BoardRepository
{
    public class BoardRepository : BaseRepository<Board>, IBoardRepository
    {
        public BoardRepository(TasklyDbContext context) : base(context)
        {
        }
    }
}
