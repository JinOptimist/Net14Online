using Net14Web.DbStuff.Models;
using Net14Web.Models.RealEstate;

namespace Net14Web.Services.RealEstate;

public class UserBuilder
{
    private IdBuilder _idBuilder;
    public UserBuilder(IdBuilder idBuilder)
    {
        _idBuilder = idBuilder;
    }

    public User BuilderUser(User addUser)
    {
        var user = new User
        {
            Name = addUser.Name,
            Age = addUser.Age,
            KindOfActivity = addUser.KindOfActivity,
        };
        return user;
    }
    
}