using Microsoft.Extensions.DependencyInjection;
using Multitenant.API.Provider;

namespace Multitenant.Infraestructure.Database.Installers
{
    public static class ServicesInstaller
    {

        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<TenantData>();
        }
    }
}
