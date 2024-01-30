using Microsoft.EntityFrameworkCore;
using Net14Web.DbStuff.Models;
using Net14Web.DbStuff.RealEstate.Models;
using Net14Web.Models.RealEstate;

namespace Net14Web.Services.RealEstate;

public class UpdateUser
{
    public ApartmentOwner Update(List<ApartmentOwner> userViewModelsApartmentOwners,int id,string name,int age,string kindOfActivity)
    {
        var user = userViewModelsApartmentOwners.FirstOrDefault(x => x.Id == id);
        user.Name = name;
        user.Age = age;
        user.KindOfActivity = kindOfActivity;
        return user;
    }
}