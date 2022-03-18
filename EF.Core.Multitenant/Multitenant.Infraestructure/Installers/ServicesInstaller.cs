using Microsoft.Extensions.DependencyInjection;
using Multitenant.API.Provider;

namespace Multitenant.Infraestructure.Database.Installers
{
    public static class ServicesInstaller
    {

        public static void InstallServices(this IServiceCollection services)
        {
            services.AddScoped<TenantData>();
        }
    }
}
