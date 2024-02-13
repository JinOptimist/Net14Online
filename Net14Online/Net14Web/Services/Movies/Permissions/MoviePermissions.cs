using Net14Web.DbStuff;
using Net14Web.DbStuff.Models;

namespace Net14Web.Services.Movies.Permissions
{
    public class MoviePermissions
    {
        private AuthService _authService;

        public MoviePermissions(AuthService authService)
        {
            _authService = authService;
        }

        private Role UserRole => _authService.GetCurrentUserRole();

        private List<Permission> UserRolePermissions => _authService.GetCurrentUserPermissions();

        public bool CanAddCommentToMovie()
            => TherePermision.IsTherePermision(UserRolePermissions, SeedExtentoin.ADD_COMMENT_TO_MOVIE);

        public bool CanAddMovie()
            => TherePermision.IsTherePermision(UserRolePermissions, SeedExtentoin.ADD_MOVIE) ||
                (UserRole.Name == SeedExtentoin.ADMIN_ROLE || UserRole.Name == SeedExtentoin.MODERATOR_ROLE);
    }
}
