using Microsoft.EntityFrameworkCore;
using RealEstateNet14Web.DbStuff.Models;

namespace RealEstateNet14Web.DbStuff.Repositories;

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

    public ApartmentOwner? GetUserByLoginAndPassword(string login, string password)
    {
        return _entyties
            .FirstOrDefault(user => user.Login!.ToLower() == login.ToLower() && user.Password == password);
    }

    public bool AnyUserWithName(string name)
    {
        return _entyties.Any(x => x.Login == name);
    }
}