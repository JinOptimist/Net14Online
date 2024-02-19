using Net14Web.DbStuff.Models;
using Net14Web.DbStuff.Models.Movies;
using Net14Web.DbStuff.Repositories;
using Net14Web.Models.Movies;

namespace Net14Web.Services.Movies
{
    public class UserBuilder
    {
        private readonly CommentBuilder _commentBuilder;
        private readonly RoleRepository _roleRepository;
        private const string DEFAULT_USER_AVATAR_IMAGE_PATH = "/images/movies/userAvatars/default.png";

        public UserBuilder(CommentBuilder commentBuilder, RoleRepository roleRepository)
        {
            _commentBuilder = commentBuilder;
            _roleRepository = roleRepository;
        }

        public UserViewModel RebuildUserToUserView(User user)
        {
            var userView = new UserViewModel
            {
                Id = user.Id,
                Login = user.Login ?? "",
                Email = user.Email ?? "",
                Password = user.Password ?? "",
                AvatarUrl = user.AvatarUrl ?? ""
            };
            return userView;
        }

        public UserViewModel RebuildUserToUserViewWithComments(User user)
        {
            var userView = new UserViewModel
            {
                Id = user.Id,
                Login = user.Login ?? "",
                Email = user.Email ?? "",
                Password = user.Password ?? "",
                AvatarUrl = user.AvatarUrl ?? "",
                Comments = user.Comments?.Select(c => _commentBuilder.BuildUserCommentView(c)).ToList() ?? new List<UserCommentViewModel>()
            };
            return userView;
        }

        public User BuildUser(AddUserViewModel addUser)
        {
            var user = new User
            {
                Login = addUser.Login,
                Email = addUser.Email,
                Password = addUser.Password,
                AvatarUrl = DEFAULT_USER_AVATAR_IMAGE_PATH,
                Comments = new List<Comment>(),
                Roles = new List<Role> { _roleRepository.GetRoleByName("User") }
            };
            return user;
        }
    }
}
