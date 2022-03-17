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
        public static void RunMigrationsOnDataBases(this IList<ApplicationContext> contexts)
        {
            foreach (var context in contexts)
                RunMigrationOnDataBase(context);
        }

        private static void RunMigrationOnDataBase(ApplicationContext context)
        {
            //var canConnect = context.Database.CanConnect();

            //if (!canConnect)
            //{
            //    context.Database.EnsureCreated();
            //}

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
    }
}
