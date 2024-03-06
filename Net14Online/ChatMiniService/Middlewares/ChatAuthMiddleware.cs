using ChatMiniService.Services;

namespace ChatMiniService.Middlewares
{
    public class ChatAuthMiddleware
    {
        private readonly RequestDelegate _next;

        public ChatAuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Path.ToString().StartsWith("/chat"))
            {
                await _next.Invoke(context);
                return;
            }

            var authTokern = context.Request.Headers[AuthService.AUTH_HEADER_NAME];

            if (string.IsNullOrEmpty(authTokern) || !authTokern.Any())
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Unauthorize request");
                return;
            }

            var authService = context.RequestServices.GetService<AuthService>();
            if (!authService.ValidateToken(authTokern))
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsync("Access forbidden");
                return;
            }

            await _next.Invoke(context);
        }
    }
}
