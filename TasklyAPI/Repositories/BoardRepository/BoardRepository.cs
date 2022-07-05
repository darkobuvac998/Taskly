using Entities.Data;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.BaseRepository;
using System.Linq.Expressions;

namespace Repositories.BoardRepository
{
    public class BoardRepository : BaseRepository<Board>, IBoardRepository
    {
        public BoardRepository(TasklyDbContext context) : base(context)
        {
        }

        public bool BoardExists(Expression<Func<Board, bool>> expression)
        {
            return dbContext.Boards.Any(expression);
        }

        public Task<bool> BoardExistsAsync(Expression<Func<Board, bool>> expression)
        {
            return dbContext.Boards.AnyAsync(expression);
        }
    }
}
