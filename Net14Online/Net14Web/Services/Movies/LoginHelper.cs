using Net14Web.Models.Movies;

namespace Net14Web.Services.Movies
{
    public class LoginHelper
    {
        public Models.Movies.UserViewModel? FindLoggedUser(List<Models.Movies.UserViewModel> Users, LoginUserViewModel loginUser)
        {
            foreach (var user in Users)
            {
                if (CheckLoggedUser(user, loginUser))
                {
                    return user;
                }
            }
            return null;
        }

        private bool CheckLoggedUser(Models.Movies.UserViewModel user, LoginUserViewModel loginingUser)
        {
            if (user.Login.ToLower() == loginingUser.Login.ToLower() && user.Password == loginingUser.Password)
            {
                return true;
            }
            return false;
        }
    }
}
