using Microsoft.EntityFrameworkCore;
using Net14Web.DbStuff.Models;
using Net14Web.DbStuff.Models.Movies;
using Net14Web.Services;

namespace Net14Web.DbStuff.Repositories
{
    public class RoleRepository : BaseRepository<Role>
    {
        private AuthService _authService;

        public RoleRepository(WebDbContext context, AuthService authService) : base(context)
        {
            _authService = authService;
        }

        public Role GetRoleByName(string roleName)
        {
            return _entyties
                .Include(e => e.Permissions)
                .FirstOrDefault(x => x.Name == roleName);
        }

        public List<Role> GetCurrentUserRoles()
        {
            var currentUser = _authService.GetCurrentUser();
            return GetUserRoles(currentUser);
        }

        public List<Role> GetUserRoles(User user)
        {
            return _entyties
                .Include(e => e.Users)
                .Where(r => r.Users.Contains(user))
                .ToList();
        }

        public List<Role> GetUserRolesAndPermissions(User user)
        {
            return _entyties
                .Include(e => e.Users)
                .Include(r => r.Permissions)
                .Where(r => r.Users.Contains(user))
                .ToList();
        }

        public void AddPermissionToRole(Permission permission, Role role)
        {
            if (role.Permissions is null)
            {
                role.Permissions = new List<Permission>();
            }
            role.Permissions.Add(permission);
            _context.SaveChanges();
        }
    }
}
