using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Net14Web.DbStuff.Repositories;

namespace Net14Web.Controllers.CustomAuthAttributes
{
    public class RoleAttribute : Attribute, IAuthorizationFilter
    {
        private string[] _roleNames;

        public RoleAttribute(params string[] roleNames)
        {
            _roleNames = roleNames;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var authUserRole = context.HttpContext.RequestServices.GetService<RoleRepository>();
            var role = authUserRole!.GetCurrentUserRoles();
            var isValidRole = _roleNames.Any(roleName => role.Any(r => r.Name == roleName));
            if (!isValidRole)
            {
                context.Result = new ForbidResult(AuthController.AUTH_KEY);
            }
        }
    }
}
