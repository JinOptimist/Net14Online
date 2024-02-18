using Microsoft.EntityFrameworkCore;
using Net14Web.DbStuff.Models;

namespace Net14Web.DbStuff.Repositories
{
    public class RoleRepository : BaseRepository<Role>
    {
        public RoleRepository(WebDbContext context) : base(context)
        {
        }

        public Role GetRoleByName(string roleName)
        {
            return _entyties
                .Include(e => e.Permissions)
                .FirstOrDefault(x => x.Name == roleName);
        }

        public void AddPermissionToRole(Permission permission, string roleName)
        {
            var role = GetRoleByName(roleName);
            if (role.Permissions is not null)
            {
                role.Permissions.Add(permission);
            }
            else
            {
                role.Permissions = new List<Permission>
                {
                    permission
                };
            }
            _context.SaveChanges();
        }
    }
}
