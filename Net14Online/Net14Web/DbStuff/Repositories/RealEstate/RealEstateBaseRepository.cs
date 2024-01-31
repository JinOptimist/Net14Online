using Microsoft.EntityFrameworkCore;
using Net14Web.DbStuff.Models;
using Net14Web.DbStuff.RealEstate;

namespace Net14Web.DbStuff.Repositories.RealEstate;

public abstract class RealEstateBaseRepository<DbModel> where DbModel : BaseModel
{

    protected readonly WebRealEstateDbContext _webRealEstateDbContext;
    protected readonly DbSet<DbModel> _entyties;

    protected RealEstateBaseRepository(WebRealEstateDbContext webRealEstateDbContext)
    {
        _webRealEstateDbContext = webRealEstateDbContext;
        _entyties = _webRealEstateDbContext.Set<DbModel>();
    }
    
    public virtual int Add(DbModel dbModel)
    {
        _entyties.Add(dbModel);
        _webRealEstateDbContext.SaveChanges();
        return dbModel.Id;
    }

    public virtual void Delete( int id)
    {
        var user = _entyties.First(x => x.Id == id);
        _entyties.Remove(user);
        _webRealEstateDbContext.SaveChanges();
    }

    public virtual DbModel GetById(int id)
    {
        var user = _entyties.SingleOrDefault(x => x.Id == id);
        return user;
    }
    
}