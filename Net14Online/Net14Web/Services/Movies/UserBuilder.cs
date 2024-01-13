using Net14Web.Models.Movies;

namespace Net14Web.Services.Movies
{
    public class UserBuilder
    {
        public UserBuilder()
        {
        }

        public UserViewModel BuildUser(int id, AddUserViewModel addUser)
        {
            UserViewModel user = new UserViewModel
            {
                Id = id,
                Login = addUser.Login,
                Email = addUser.Email,
                Password = addUser.Password,
                AvatarUrl = "https://goo.su/w7Qh",
                Comments = new()
            };
            return user;
        }
    }
}
