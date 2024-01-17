using Net14Web.DbStuff.Models.Movies;
using Net14Web.Models.Movies;

namespace Net14Web.Services.Movies
{
    public class UserEditHelper
    {
        public void EditUser(User oldUser, UserViewModel updateUser)
        {
            oldUser.Email = updateUser.Email;
            oldUser.Login = updateUser.Login;
            oldUser.Password = updateUser.Password;
        }
    }
}
