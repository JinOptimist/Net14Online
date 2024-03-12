using Microsoft.EntityFrameworkCore;
using RealEstateNet14Web.DbStuff.Models;

namespace RealEstateNet14Web.DbStuff.Repositories;

public class ApartamentRepository : RealEstateBaseRepository<Apartament>
{
    public ApartamentRepository(WebRealEstateDbContext webRealEstateDbContext) : base(webRealEstateDbContext){}

    public List<Apartament> GetApartamentsAndApartmentOwner(int count)
    {
        return _webRealEstateDbContext.Apartaments.
            Include(x => x.ApartmentOwner).ToList();
    }
}