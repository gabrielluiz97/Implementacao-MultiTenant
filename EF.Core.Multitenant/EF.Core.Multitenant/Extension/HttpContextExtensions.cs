using Microsoft.AspNetCore.Http;

namespace Multitenant.API.Extension
{
    public static class HttpContextExtensions
    {
        public static string GetTenantId(this HttpContext httpContext)
        {
            //desenvolvedor.io/tenant-1/product -> tenant-1/product
            //posso capturar o tenant de outros lugares também
            var tenant = httpContext.Request.Path.Value.Split('/', System.StringSplitOptions.RemoveEmptyEntries)[0];

            return tenant;
        }
    }
}
