using Multitenant.Domain;
using Multitenant.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Core.Multitenant
{
    public static class SeedsInitilizer
    {
        public static void RunMigrations(this IApplicationBuilder application)
        {
            using var db = application.ApplicationServices
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<ApplicationContext>();

            var canConnect = db.Database.CanConnect();

            if (!canConnect)
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
            }

        }
    }
}
