using RealEstateNet14Web.Services;
using System.Globalization;
using RealEstateNet14Web.Services.Auth;

namespace RealEstateNet14Web.CustomMiddlewares
{
    public class CustomLocalizationMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomLocalizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            CultureInfo culture;
            var localFromCulture = context.Request.Cookies["langues"];
            if (localFromCulture == null)
            {
                string acceptLanguage = context.Request.Headers.AcceptLanguage;
                var locale = acceptLanguage.Substring(0, 5);
                culture = new CultureInfo(locale);
            }
            else
            {
                culture = new CultureInfo(localFromCulture);
            }

            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            await _next.Invoke(context);
        }
    }
}