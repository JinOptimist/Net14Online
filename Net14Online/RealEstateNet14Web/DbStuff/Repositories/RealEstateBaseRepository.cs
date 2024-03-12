using Microsoft.EntityFrameworkCore;
using RealEstateNet14Web.DbStuff.Models;

namespace RealEstateNet14Web.DbStuff.Repositories;

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
        var apartmentOwner = _entyties.First(x => x.Id == id);
        _entyties.Remove(apartmentOwner);
        _webRealEstateDbContext.SaveChanges();
    }

    public virtual DbModel GetById(int id)
    {
        var apartmentOwner = _entyties.SingleOrDefault(x => x.Id == id);
        return apartmentOwner;
    }
}