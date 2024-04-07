using Microsoft.EntityFrameworkCore;
using RealEstateNet14Web.DbStuff.Models;

namespace RealEstateNet14Web.DbStuff.Repositories;

public class RealEstateOwnerRepository : RealEstateBaseRepository<RealEstateOwner>
{
    public RealEstateOwnerRepository(WebRealEstateDbContext webRealEstateDbContext) : base(webRealEstateDbContext) {}

    public List<RealEstateOwner> GetApartamentOwners(int count)
    {
        return _webRealEstateDbContext.RealEstateOwners.Take(count).ToList();
    }

    public void Update(RealEstateOwner realEstateOwner,string name, int age, string kindOfActivity)
    {
        realEstateOwner.Name = name;
        realEstateOwner.Age = age;
        realEstateOwner.KindOfActivity = kindOfActivity;
        _webRealEstateDbContext.SaveChanges();
    }

    public RealEstateOwner? GetUserByLoginAndPassword(string login, string password)
    {
        return _entyties
            .FirstOrDefault(user => user.Login!.ToLower() == login.ToLower() && user.Password == password);
    }

    public bool AnyUserWithName(string name)
    {
        return _entyties.Any(x => x.Login == name);
    }
}