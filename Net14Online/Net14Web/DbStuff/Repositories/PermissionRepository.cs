using Microsoft.EntityFrameworkCore;
using Net14Web.DbStuff.Models;
using Net14Web.DbStuff.Models.Movies;
using Net14Web.Services;

namespace Net14Web.DbStuff.Repositories
{
    public class PermissionRepository : BaseRepository<Permission>
    {
        private AuthService _authService;

        public PermissionRepository(WebDbContext context, AuthService authService) : base(context)
        {
            _authService = authService;
        }

        public List<Permission> GetCurrentUserPermissions()
        {
            var currentUser = _authService.GetCurrentUser();
            return GetUserPermissions(currentUser);
        }

        public List<Permission> GetUserPermissions(User user)
        {
            return _entyties
                .Include(e => e.Roles)
                .ThenInclude(r => r.Users)
                .Where(p => p.Roles.Where(r => r.Users.Contains(user)).Count() > 0)
                .ToList();
        }

        public Permission GetPermissionByType(PermissionType type)
        {
            return _entyties
                .Include(e => e.Roles)
                .FirstOrDefault(x => x.Type == type);
        }

        public List<Permission> GetRolePermissions(Role role)
        {
            return _entyties
                .Include(e => e.Roles)
                .Where(r => r.Roles.Contains(role))
                .ToList();
        }
    }
}
