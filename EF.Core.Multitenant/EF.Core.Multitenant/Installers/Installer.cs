using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Multitenant.API.Extension;
using Multitenant.API.Provider;
using Multitenant.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multitenant.Infraestructure.Database.Installers
{
    public static class Installer
    {

        public static void InstallDependenceInjections(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<TenantData>();

            builder.Services.AddScoped<ApplicationContext>((provider) =>
            {
                var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();

                var httpContext = provider.GetService<IHttpContextAccessor>()?.HttpContext;

                var tenantId = httpContext?.GetTenantId();

                var connectionString = builder.Configuration.GetConnectionString(tenantId) ?? builder.Configuration.GetConnectionString("tenantz");

                optionsBuilder
                    .UseNpgsql(connectionString)
                    .LogTo(Console.WriteLine)
                    .EnableSensitiveDataLogging();

                return new ApplicationContext(optionsBuilder.Options);
            });

        }
    }
}
