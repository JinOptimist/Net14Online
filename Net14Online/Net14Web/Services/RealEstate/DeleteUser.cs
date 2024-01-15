using Net14Web.Models.RealEstate;

namespace Net14Web.Services.RealEstate;

public class DeleteUser
{
    public UserViewModel UserDelete(List<UserViewModel> userViewModels, string id)
    {
        var deleteUser = userViewModels.First(x => x.Id == id);
        return deleteUser;
    }
    
}