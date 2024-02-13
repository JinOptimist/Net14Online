using Net14Web.DbStuff;
using Net14Web.DbStuff.Models;

namespace Net14Web.Services.Movies.Permissions
{
    public class UserPermissions
    {
        private AuthService _authService;

        public UserPermissions(AuthService authService)
        {
            _authService = authService;
        }

        private Role UserRole => _authService.GetCurrentUserRole();

        private List<Permission> UserRolePermissions => _authService.GetCurrentUserPermissions();

        public bool CanUpdateAvatarUser(int userId)
            => TherePermision.IsTherePermision(UserRolePermissions, SeedExtentoin.ADD_COMMENT_TO_MOVIE) ||
                _authService.GetCurrentUserId() == userId;
    }
}
