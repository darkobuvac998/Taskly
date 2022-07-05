using Entities.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Repositories.BaseRepository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly TasklyDbContext dbContext;

        public BaseRepository(TasklyDbContext context)
        {
            dbContext = context;
        }

        public TEntity Create(TEntity entity)
        {
            dbContext.Set<TEntity>().Add(entity);
            Save();
            return entity;
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            await dbContext.Set<TEntity>().AddAsync(entity);
            await SaveAsync();
            return entity;
        }

        public bool Delete(TEntity entity)
        {
            dbContext.Set<TEntity>().Remove(entity);
            return Save() > 0;
        }

        public async Task<bool> DeleteAsync(TEntity entity)
        {
            dbContext.Set<TEntity>().Remove(entity);
            return await SaveAsync() > 0;
        }

        public virtual ICollection<TEntity> GetAll(bool trackChanges = true)
        {
            return trackChanges ? dbContext.Set<TEntity>().ToList() : dbContext.Set<TEntity>().AsNoTracking().ToList();
        }

        public virtual async Task<ICollection<TEntity>> GetAllAsync(bool trackChanges = true)
        {
            return trackChanges ? await dbContext.Set<TEntity>().ToListAsync() : await dbContext.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public TEntity? GetByCondition(Expression<Func<TEntity, bool>> expression, bool trackChanges = true)
        {
            return trackChanges ? dbContext.Set<TEntity>().Where(expression).FirstOrDefault()
                : dbContext.Set<TEntity>().Where(expression).AsNoTracking().FirstOrDefault();
        }

        public Task<TEntity?> GetByConditionAsync(Expression<Func<TEntity, bool>> expression, bool trackChanges = true)
        {
            return trackChanges ? dbContext.Set<TEntity>().Where(expression).FirstOrDefaultAsync()
                : dbContext.Set<TEntity>().Where(expression).AsNoTracking().FirstOrDefaultAsync();
        }

        public int Save()
        {
            return dbContext.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await dbContext.SaveChangesAsync();
        }

        public TEntity Update(TEntity entity)
        {
            dbContext.Set<TEntity>().Update(entity);
            Save();
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            dbContext.Set<TEntity>().Update(entity);
            await SaveAsync();
            return entity;
        }
    }
}
