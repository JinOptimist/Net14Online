using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Net14Web.Services;
using System.Linq;

namespace Net14Web.Controllers.CustomAuthAttributes
{
    public class PermissionAttribute : Attribute, IAuthorizationFilter
    {
        private string[] _permissionNames;

        public PermissionAttribute(params string[] permissionNames)
        {
            _permissionNames = permissionNames;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var authService = context.HttpContext.RequestServices.GetService<AuthService>();
            var userPermissions = authService.GetCurrentUserPermissions();
            foreach (var permission in userPermissions )
            {
                if (_permissionNames.FirstOrDefault(p => p.Equals(permission.Name)) is not null)
                {
                    return;
                }
            }
            context.Result = new ForbidResult(AuthController.AUTH_KEY);
        }
    }
}
