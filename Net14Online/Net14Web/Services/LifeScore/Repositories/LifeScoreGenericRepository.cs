using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Net14Web.DbStuff.Models;
using Net14Web.DbStuff;

namespace Net14Web.Services.LifeScore.Repositories
{
    public class LifeScoreGenericRepository<TEntity> : ILifeScoreGenericRepository<TEntity> where TEntity : BaseModel
    {
        private readonly WebDbContext _db;
        private readonly DbSet<TEntity> _entities;

        public LifeScoreGenericRepository(WebDbContext db)
        {
            _db = db;
            _entities = _db.Set<TEntity>();
        }

        public async Task<List<TEntity>> GetAllAsync(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            var query = _entities.AsQueryable();
            if (include != null)
            {
                query = include.Invoke(query);
            }
            return await query
                    .AsNoTracking()
                    .ToListAsync();
        }

        public async Task<TEntity> GetAsync(int id)
        {
            return await _entities
                .AsNoTracking()
                .FirstAsync(p => p.Id == id);
        }

        public async Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            var query = _entities.AsQueryable();
            query = query.Where(predicate);
            if (include != null)
            {
                query = include.Invoke(query);
            }
            return await query
                    .AsNoTracking()
                    .ToListAsync();
        }

        public async Task<TEntity> FirstAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            var query = _entities.AsQueryable();
            query = query.Where(predicate);
            if (include != null)
            {
                query = include.Invoke(query);
            }
            return await query
                    .FirstAsync();
        }

        public async Task<TEntity> CreateAsync(TEntity item, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            _entities.Add(item);
            await _db.SaveChangesAsync();

            return item;
        }

        public async Task<TEntity> UpdateAsync(TEntity item)
        {
            _entities.Update(item);
            await _db.SaveChangesAsync();

            return item;
        }

        public async Task DeleteAsync(TEntity item)
        {
            _entities.Remove(item);
            await _db.SaveChangesAsync();
        }
    }
}
