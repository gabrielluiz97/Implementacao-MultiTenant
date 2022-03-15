using Multitenant.API.Provider;
using Multitenant.API.Extension;

namespace Multitenant.API.Midleware
{
    public class TenantMidleware
    {
       private readonly RequestDelegate _next;

        public TenantMidleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            var tenant = httpContext.RequestServices.GetRequiredService<TenantData>();

            tenant.TenantId = httpContext.GetTenantId();

            await _next(httpContext);
        }
    }
}
