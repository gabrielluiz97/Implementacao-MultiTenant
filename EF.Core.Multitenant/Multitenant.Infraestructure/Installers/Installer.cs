using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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

        public static void InstallDependenceInjections(this IServiceCollection services)
        {
            services.AddScoped<TenantData>();
        }
    }
}
