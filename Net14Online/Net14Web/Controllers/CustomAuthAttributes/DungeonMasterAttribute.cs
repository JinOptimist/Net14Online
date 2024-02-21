using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Net14Web.Services;

namespace Net14Web.Controllers.CustomAuthAttributes
{
    public class DungeonMasterAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var service = context.HttpContext.RequestServices.GetService<AuthService>();
            foreach (var role in service.GetCurrentUser().Roles)
            {
                if (role.Name != "dm")
                {
                    context.Result = new ForbidResult(AuthController.AUTH_KEY);
                }
            }
        }
    }
}
