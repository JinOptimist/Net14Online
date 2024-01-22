using Net14Web.DbStuff.Models;
using Net14Web.Models.RealEstate;

namespace Net14Web.Services.RealEstate;

public class UpdateUser
{
    public User Update(List<User> users,int id,string name,int age,string kindOfActivity)
    {
        var user = users.First(x => x.Id == id);
        user.Name = name;
        user.Age = age;
        user.KindOfActivity = kindOfActivity;
        return user;
    }
}