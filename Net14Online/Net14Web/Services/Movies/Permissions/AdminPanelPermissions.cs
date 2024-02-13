using Net14Web.DbStuff;
using Net14Web.DbStuff.Models;

namespace Net14Web.Services.Movies.Permissions
{
    public class AdminPanelPermissions
    {
        private AuthService _authService;

        public AdminPanelPermissions(AuthService authService)
        {
            _authService = authService;
        }

        private Role UserRole => _authService.GetCurrentUserRole();

        private List<Permission> UserRolePermissions => _authService.GetCurrentUserPermissions();

        public bool CanAddMovie()
            => TherePermision.IsTherePermision(UserRolePermissions, SeedExtentoin.ADD_MOVIE) ||
                (UserRole.Name == SeedExtentoin.ADMIN_ROLE || UserRole.Name == SeedExtentoin.MODERATOR_ROLE);

        public bool CanUpdateMovie()
            => TherePermision.IsTherePermision(UserRolePermissions, SeedExtentoin.EDIT_MOVIE) ||
                (UserRole.Name == SeedExtentoin.ADMIN_ROLE || UserRole.Name == SeedExtentoin.MODERATOR_ROLE);

        public bool CanDeleteMovie()
            => TherePermision.IsTherePermision(UserRolePermissions, SeedExtentoin.DELETE_MOVIE) ||
                (UserRole.Name == SeedExtentoin.ADMIN_ROLE);

        public bool CanUpdateUser()
            => TherePermision.IsTherePermision(UserRolePermissions, SeedExtentoin.EDIT_USER) ||
                (UserRole.Name == SeedExtentoin.ADMIN_ROLE);

        public bool CanDeleteUser()
            => TherePermision.IsTherePermision(UserRolePermissions, SeedExtentoin.DELETE_USER) ||
                (UserRole.Name == SeedExtentoin.ADMIN_ROLE);

        public bool CanAccessToAdminPanel()
            => TherePermision.IsTherePermision(UserRolePermissions, SeedExtentoin.ACCESS_TO_ADMIN_PANEL) &&
                (UserRole.Name == SeedExtentoin.ADMIN_ROLE || UserRole.Name == SeedExtentoin.MODERATOR_ROLE);
    }
}
