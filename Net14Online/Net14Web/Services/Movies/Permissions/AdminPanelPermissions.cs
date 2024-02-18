using Net14Web.DbStuff;
using Net14Web.DbStuff.Models;
using Net14Web.DbStuff.Repositories;

namespace Net14Web.Services.Movies.Permissions
{
    public class AdminPanelPermissions
    {
        private RoleRepository _roleRepository;
        private PermissionRepository _permissionRepository;

        public AdminPanelPermissions(RoleRepository roleRepository, PermissionRepository permissionRepository)
        {
            _roleRepository = roleRepository;
            _permissionRepository = permissionRepository;
        }

        private List<Role> UserRoles => _roleRepository.GetCurrentUserRoles();

        private List<Permission> UserRolePermissions => _permissionRepository.GetCurrentUserPermissions();

        public bool CanAddMovie()
            => TherePermision.IsTherePermision(UserRolePermissions, PermissionType.AddMovie) ||
               RolePermision.IsThereRole(UserRoles, SeedExtentoin.ADMIN_ROLE, SeedExtentoin.MODERATOR_ROLE);


        public bool CanUpdateMovie()
            => TherePermision.IsTherePermision(UserRolePermissions, PermissionType.EditMovie) ||
               RolePermision.IsThereRole(UserRoles, SeedExtentoin.ADMIN_ROLE, SeedExtentoin.MODERATOR_ROLE);

        public bool CanDeleteMovie()
            => TherePermision.IsTherePermision(UserRolePermissions, PermissionType.DeleteMovie) ||
               RolePermision.IsThereRole(UserRoles, SeedExtentoin.ADMIN_ROLE);

        public bool CanUpdateUser()
            => TherePermision.IsTherePermision(UserRolePermissions, PermissionType.EditUser) ||
               RolePermision.IsThereRole(UserRoles, SeedExtentoin.ADMIN_ROLE);

        public bool CanDeleteUser()
            => TherePermision.IsTherePermision(UserRolePermissions, PermissionType.DeleteUser) ||
               RolePermision.IsThereRole(UserRoles, SeedExtentoin.ADMIN_ROLE);

        public bool CanAccessToAdminPanel()
            => TherePermision.IsTherePermision(UserRolePermissions, PermissionType.AccessToAdminPanel) &&
               RolePermision.IsThereRole(UserRoles, SeedExtentoin.ADMIN_ROLE, SeedExtentoin.MODERATOR_ROLE);
    }
}
