using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Net14Web.Services;

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
            var authService = context.HttpContext.RequestServices.GetService<AuthService>();
            var role = authService!.GetCurrentUserRole();
            var isValidRole = _roleNames.Any(r => r == role.Name);
            if (!isValidRole)
            {
                context.Result = new ForbidResult(AuthController.AUTH_KEY);
            }
        }
    }
}
