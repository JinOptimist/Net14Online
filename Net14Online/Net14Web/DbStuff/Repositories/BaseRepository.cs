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
    }
}
