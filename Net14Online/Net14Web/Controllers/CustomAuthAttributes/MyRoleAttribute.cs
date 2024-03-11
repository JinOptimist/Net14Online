using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Net14Web.Services;

namespace Net14Web.Controllers.CustomAuthAttributes
{
    public class MyRoleAttribute : Attribute, IAuthorizationFilter
    {
        private string _roleName;

        public MyRoleAttribute(string role)
        {
            _roleName = role;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var authService = context.HttpContext.RequestServices.GetService<AuthService>();
            foreach (var role in authService.GetCurrentUser().Roles)
            {
                if (role.Name != _roleName)
                {
                    context.Result = new ForbidResult(AuthController.AUTH_KEY);
                }
            }
        }
    }
}