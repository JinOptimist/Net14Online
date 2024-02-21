using Net14Web.DbStuff;
using Net14Web.DbStuff.Models;
using Net14Web.DbStuff.Repositories;

namespace Net14Web.Services.Movies.Permissions
{
    public class CommentPermissions
    {
        private AuthService _authService;
        private RoleRepository _roleRepository;
        private PermissionRepository _permissionRepository;

        public CommentPermissions(AuthService authService, RoleRepository roleRepository, PermissionRepository permissionRepository)
        {
            _authService = authService;
            _roleRepository = roleRepository;
            _permissionRepository = permissionRepository;
        }

        private List<Role> UserRoles => _roleRepository.GetCurrentUserRoles();

        private List<Permission> UserRolePermissions => _permissionRepository.GetCurrentUserPermissions();

        public bool CanDeleteCommentFromMovie(int userId)
            => (TherePermision.IsTherePermision(UserRolePermissions, PermissionType.DeleteCommentOnMovie) 
                && userId == _authService.GetCurrentUserId()) ||
               RolePermision.IsThereRole(UserRoles, SeedExtentoin.ADMIN_ROLE, SeedExtentoin.MODERATOR_ROLE);
    }
}
