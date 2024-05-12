using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Net14Web.Services;

namespace Net14Web.Controllers.CustomAuthAttributes
{
    public class UserRestrictionAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var authService = context.HttpContext.RequestServices.GetService<AuthService>();
            if (authService.IsUser())
            {
                context.Result = new ForbidResult(AuthController.AUTH_KEY);
            }
        }
    }
}
