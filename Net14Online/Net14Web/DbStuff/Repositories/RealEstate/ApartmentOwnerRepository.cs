using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Net14Web.DbStuff.RealEstate;
using Net14Web.DbStuff.RealEstate.Models;

namespace Net14Web.DbStuff.Repositories.RealEstate;

public class ApartmentOwnerRepository : RealEstateBaseRepository<ApartmentOwner>
{

    public ApartmentOwnerRepository(WebRealEstateDbContext webRealEstateDbContext) : base(webRealEstateDbContext) {}

    public List<ApartmentOwner> GetApartamentOwners(int count)
    {
        return _webRealEstateDbContext.ApartmentOwners.Take(count).ToList();
    }

    public void Update(ApartmentOwner apartmentOwner,string name, int age, string kindOfActivity)
    {
        apartmentOwner.Name = name;
        apartmentOwner.Age = age;
        apartmentOwner.KindOfActivity = kindOfActivity;
        _webRealEstateDbContext.SaveChanges();
    }
    public ApartmentOwner GetUserByLoginAndPassword(string login, string password)
    {
        return _entyties
            .FirstOrDefault(apartmentOwner => apartmentOwner.Login!.ToLower() == login.ToLower() && apartmentOwner.Password == password);
    }
}