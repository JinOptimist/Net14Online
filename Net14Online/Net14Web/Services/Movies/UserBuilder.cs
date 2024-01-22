using Net14Web.DbStuff.Models.Movies;
using Net14Web.Models.Movies;
using Net14Web.Models.RetroConsoles;

namespace Net14Web.Services.Movies
{
    public class UserBuilder
    {
        public UserViewModel BuildUserView(int id, AddUserViewModel addUser)
        {
            var user = new UserViewModel
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

        public List<UserViewModel> RebuildUsersToUrsesViewModel(List<User> users)
        {
            var userView = users.
                Select(user => new UserViewModel
                {
                    Id = user.Id,
                    Login = user.Login,
                    Email = user.Email,
                    Password = user.Password,
                    AvatarUrl = "https://goo.su/w7Qh",
                    Comments = new()
                }).ToList();
            return userView;
        }

        public UserViewModel RebuildUserToUserView(User user)
        {
            var userView = new UserViewModel
            {
                Id = user.Id,
                Login = user.Login,
                Email = user.Email,
                Password = user.Password,
                AvatarUrl = "https://goo.su/w7Qh",
                Comments = new()
            };
            return userView;
        }

        public User BuildUser(UserViewModel addUser)
        {
            var user = new User
            {
                Login = addUser.Login,
                Email = addUser.Email,
                Password = addUser.Password
            };
            return user;
        }

        public User BuildUser(AddUserViewModel addUser)
        {
            var user = new User
            {
                Login = addUser.Login,
                Email = "test@test.com",
                Password = addUser.Password
            };
            return user;
        }
    }
}
