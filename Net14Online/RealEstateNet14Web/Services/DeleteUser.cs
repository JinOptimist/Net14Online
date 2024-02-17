using RealEstateNet14Web.DbStuff.Models;

namespace RealEstateNet14Web.Services;

public class DeleteUser
{
    public ApartmentOwner UserDelete(List<ApartmentOwner> userViewModelsApartmentOwners,int id)
    {
        var deleteUser = userViewModelsApartmentOwners.First(x => x.Id == id);
        return deleteUser;
    }
}