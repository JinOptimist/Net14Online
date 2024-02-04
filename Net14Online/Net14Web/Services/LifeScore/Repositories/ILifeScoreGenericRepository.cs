using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Net14Web.Services.LifeScore.Repositories
{
    public interface ILifeScoreGenericRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAllAsync(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);
        Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);
        Task<TEntity> FirstAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);
        Task<TEntity> GetAsync(int id);
        Task<TEntity> CreateAsync(TEntity item, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);
        Task<TEntity> UpdateAsync(TEntity item);
        Task DeleteAsync(TEntity item);
    }
}
