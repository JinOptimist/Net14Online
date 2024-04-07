using Microsoft.EntityFrameworkCore;
using RealEstateNet14Web.DbStuff.Models;

namespace RealEstateNet14Web.DbStuff.Repositories;

public class RealEstateRepository : RealEstateBaseRepository<RealEstate>
{
    public RealEstateRepository(WebRealEstateDbContext webRealEstateDbContext) : base(webRealEstateDbContext){}

    public List<RealEstate> GetRealEstatesAndRealEstateOwner(int count)
    {
        return _webRealEstateDbContext.RealEstates.
            Include(x => x.RealEstateOwner).ToList();
    }
}