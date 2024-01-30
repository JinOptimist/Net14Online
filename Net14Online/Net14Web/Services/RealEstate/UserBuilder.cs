using Net14Web.DbStuff.Models;
using Net14Web.DbStuff.RealEstate.Models;
using Net14Web.Models.RealEstate;

namespace Net14Web.Services.RealEstate;

public class UserBuilder
{

    public ApartmentOwner BuilderUser(AddUserViewModel addUser)
    {
        var user = new ApartmentOwner()
        {
            Name = addUser.Name,
            Age = addUser.Age,
            KindOfActivity = addUser.KindOfActivity,
        };
        return user;
    }
    
}