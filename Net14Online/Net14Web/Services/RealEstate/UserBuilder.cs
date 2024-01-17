using Net14Web.Models.RealEstate;

namespace Net14Web.Services.RealEstate;

public class UserBuilder
{
    private IdBuilder _idBuilder;
    public UserBuilder(IdBuilder idBuilder)
    {
        _idBuilder = idBuilder;
    }

    public UserViewModel BuilderUser(AddUserViewModel addUser)
    {
        var user = new UserViewModel
        {
            Name = addUser.Name,
            Age = addUser.Age,
            KindOfActivity = addUser.KindOfActivity,
            Id = _idBuilder.GenerateID()
            
        };
        return user;
    }
    
}