using Microsoft.EntityFrameworkCore;
using Net14Web.DbStuff.Models;
using Net14Web.DbStuff.RealEstate.Models;
using Net14Web.Models.RealEstate;

namespace Net14Web.Services.RealEstate;

public class DeleteUser
{
    public ApartmentOwner UserDelete(List<ApartmentOwner> userViewModelsApartmentOwners,int id)
    {
        var deleteUser = userViewModelsApartmentOwners.First(x => x.Id == id);
        return deleteUser;
    }
    
}