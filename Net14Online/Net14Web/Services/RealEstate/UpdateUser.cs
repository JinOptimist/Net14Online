using Net14Web.Models.RealEstate;

namespace Net14Web.Services.RealEstate;

public class UpdateUser
{
    public UserViewModel Update(List<UserViewModel> userViewModels,string id,string name,int age,string kindOfActivity)
    {
        var user = userViewModels.First(x => x.Id == id);
        user.Name = name;
        user.Age = age;
        user.KindOfActivity = kindOfActivity;
        return user;
    }
}