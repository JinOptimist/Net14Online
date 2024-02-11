using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Net14Web.DbStuff.RealEstate;
using Net14Web.DbStuff.RealEstate.Models;

namespace Net14Web.DbStuff.Repositories.RealEstate;

public class ApartmentRepository : RealEstateBaseRepository<Apartament>
{
    public ApartmentRepository(WebRealEstateDbContext webRealEstateDbContext) : base(webRealEstateDbContext){}
    
    public List<Apartament> GetApartamentsAndApartmentOwners(int count)
    {
        return _entyties
            .Include(x => x.ApartmentOwner)
            .Take(count)
            .ToList();
    }
}