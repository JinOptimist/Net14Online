using Net14Web.DbStuff.Models;

namespace Net14Web.Services.Movies.Permissions
{
    public static class TherePermision
    {
        public static bool IsTherePermision(List<Permission> permissions, string permissionName)
        {
            return permissions.Where(perm => perm.Name == permissionName).Count() > 0;
        }
    }
}
