using Net14Web.DbStuff.Models;

namespace Net14Web.Services.Movies.Permissions
{
    public static class RolePermision
    {
        public static bool IsThereRole(List<Role> Roles, params string[] roleNames)
        {
            return roleNames.Any(rN => Roles.Any(r => r.Name == rN));
        }
    }
}
