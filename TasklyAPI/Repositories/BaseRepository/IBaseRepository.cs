using System.Linq.Expressions;

namespace Repositories.BaseRepository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        ICollection<TEntity> GetAll(bool trackChanges = true);
        TEntity? GetByCondition(Expression<Func<TEntity, bool>> expression, bool trackChanges = true);
        TEntity Create(TEntity entity);
        TEntity Update(TEntity entity);
        bool Delete(TEntity entity);
        int Save();

        Task<ICollection<TEntity>> GetAllAsync(bool trackChanges = true);
        Task<TEntity?> GetByConditionAsync(Expression<Func<TEntity, bool>> expression, bool trackChanges = true);
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync(TEntity entity);
        Task<int> SaveAsync();

    }
}
