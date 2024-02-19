using Net14Web.DbStuff.Models;

namespace Net14Web.Services.Movies.Permissions
{
    public static class TherePermision
    {
        public static bool IsTherePermision(List<Permission> permissions, PermissionType permissionType)
        {
            return permissions.Any(perm => perm.Type == permissionType);
        }
    }
}
