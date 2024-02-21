using Microsoft.EntityFrameworkCore;
using ManagementCompany.DbStuff.Models;

namespace ManagementCompany.DbStuff.Repositories
{
    public abstract class BaseRepository<DbModel>
        where DbModel : BaseModel
    {
        protected readonly ManagementCompanyDbContext _context;
        protected readonly DbSet<DbModel> _entities;

        protected BaseRepository(ManagementCompanyDbContext context)
        {
            _context = context;
            _entities = _context.Set<DbModel>();
        }

        public virtual DbModel GetById(int id)
        {
            return _entities.SingleOrDefault(ent => ent.Id == id);
        }

        public virtual int Add(DbModel dbModel)
        {
            _entities.Add(dbModel);
            _context.SaveChanges();
            return dbModel.Id;
        }

        public virtual void Delete(int id)
        {
            var entity = _entities.First(x => x.Id == id);
            _entities.Remove(entity);
            _context.SaveChanges();
        }

        public virtual IEnumerable<DbModel> GetAll()
        {
            return _entities
                .ToList();
        }

        public virtual bool Any()
        {
            return _entities.Any();
        }
    }
}
