using Net14Web.DbStuff;
using Net14Web.DbStuff.Models;

namespace Net14Web.Services.Movies.Permissions
{
    public class CommentPermissions
    {
        private AuthService _authService;

        public CommentPermissions(AuthService authService)
        {
            _authService = authService;
        }

        private Role UserRole => _authService.GetCurrentUserRole();

        private List<Permission> UserRolePermissions => _authService.GetCurrentUserPermissions();

        public bool CanRemoveCommentFromMovie(int userId)
            => TherePermision.IsTherePermision(UserRolePermissions, SeedExtentoin.DELETE_COMMENT_ON_MOVIE) 
                && userId == _authService.GetCurrentUserId() ||
                (UserRole.Name == SeedExtentoin.ADMIN_ROLE || UserRole.Name == SeedExtentoin.MODERATOR_ROLE);
    }
}
