using Microsoft.EntityFrameworkCore;
using Net14Web.DbStuff.Models;

namespace Net14Web.DbStuff.Repositories
{
    public abstract class BaseRepository<DbModel>
        where DbModel : BaseModel
    {
        protected readonly WebDbContext _context;
        protected readonly DbSet<DbModel> _entyties;

        protected BaseRepository(WebDbContext context)
        {
            _context = context;
            _entyties = _context.Set<DbModel>();
        }

        public virtual DbModel GetById(int id)
        {
            return _entyties.SingleOrDefault(ent => ent.Id == id);
        }

        public virtual int Add(DbModel dbModel)
        {
            _entyties.Add(dbModel);
            _context.SaveChanges();
            return dbModel.Id;
        }

        public virtual void Delete(int id)
        {
            var weapon = _entyties.First(x => x.Id == id);
            _entyties.Remove(weapon);
            _context.SaveChanges();
        }

        public virtual IEnumerable<DbModel> GetAll()
        {
            return _entyties
                .ToList();
        }

        public virtual async Task<DbModel?> GetByIdAsync(int id)
        {
            return await _entyties.FirstOrDefaultAsync(x => x.Id == id);
        }

        public virtual async Task AddAsync(DbModel entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await _entyties.FirstAsync(x => x.Id == id);
            _entyties.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<List<DbModel>> GetAllAsync()
        {
            return await _entyties.ToListAsync();
        }

        public virtual bool Any()
            => _entyties.Any();
    }
}
