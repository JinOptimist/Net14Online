using Net14Web.Models.Movies;

namespace Net14Web.Services.Movies
{
    public class LoginHelper
    {
        public DbStuff.Models.Movies.User? FindLoggedUser(List<DbStuff.Models.Movies.User> Users, LoginUserViewModel loginUser)
        {
            var user  = Users.FirstOrDefault(u => u.Login.ToLower() == loginUser.Login.ToLower() && u.Password == loginUser.Password);
            return user;
        }
    }
}
