using Net14Web.DbStuff;
using Net14Web.DbStuff.Models;
using Net14Web.DbStuff.Repositories;

namespace Net14Web.Services.Movies.Permissions
{
    public class MoviePermissions
    {
        private RoleRepository _roleRepository;
        private PermissionRepository _permissionRepository;

        public MoviePermissions(RoleRepository roleRepository, PermissionRepository permissionRepository)
        {
            _roleRepository = roleRepository;
            _permissionRepository = permissionRepository;
        }

        private List<Role> UserRoles => _roleRepository.GetCurrentUserRoles();

        private List<Permission> UserRolePermissions => _permissionRepository.GetCurrentUserPermissions();

        public bool CanAddCommentToMovie()
            => TherePermision.IsTherePermision(UserRolePermissions, PermissionType.AddCommentToMovie);

        public bool CanAddMovie()
            => TherePermision.IsTherePermision(UserRolePermissions, PermissionType.AddMovie) ||
               RolePermision.IsThereRole(UserRoles, SeedExtentoin.ADMIN_ROLE, SeedExtentoin.MODERATOR_ROLE);
    }
}
