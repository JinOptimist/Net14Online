using Net14Web.DbStuff.Models;
using Net14Web.Models.RealEstate;

namespace Net14Web.Services.RealEstate;

public class DeleteUser
{
    public User UserDelete(List<User> userViewModels,int id)
    {
        var deleteUser = userViewModels.First(x => x.Id == id);
        return deleteUser;
    }
    
}