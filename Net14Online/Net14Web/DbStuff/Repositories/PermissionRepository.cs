using Microsoft.EntityFrameworkCore;
using Net14Web.DbStuff.Models;

namespace Net14Web.DbStuff.Repositories
{
    public class PermissionRepository : BaseRepository<Permission>
    {
        public PermissionRepository(WebDbContext context) : base(context)
        {
        }

        public Permission GetPermissionByName(string permissionName)
        {
            return _entyties
                .Include(e => e.Roles)
                .FirstOrDefault(x => x.Name == permissionName);
        }

        public void AddRoleToPermission(Role role, string permissionName)
        {
            var permission = GetPermissionByName(permissionName);

            if (permission.Roles is not null)
            {
                if (role.Permissions?.FirstOrDefault(p => p.Name == permissionName) is not null)
                {
                    return;
                }

                permission.Roles.Add(role);
            }
            else
            {
                permission.Roles = new List<Role>
                {
                    role
                };
            }
            _context.SaveChanges();
        }
    }
}
