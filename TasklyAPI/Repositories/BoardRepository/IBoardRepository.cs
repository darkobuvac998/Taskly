using Entities.Models;
using Repositories.BaseRepository;
using System.Linq.Expressions;

namespace Repositories.BoardRepository
{
    public interface IBoardRepository : IBaseRepository<Board>
    {
        bool BoardExists(Expression<Func<Board, bool>> expression);
        Task<bool> BoardExistsAsync(Expression<Func<Board, bool>> expression);
    }
}
