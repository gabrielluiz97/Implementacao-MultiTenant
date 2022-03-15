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
        public static void Initialize(IApplicationBuilder application)
        {
            using var db = application.ApplicationServices
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<ApplicationContext>();

            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            //for (var i = 1; i <= 5; i++)
            //{
            //    db.People.Add(new Person { Name = $"Person {i}'" });
            //    db.Products.Add(new Product { Description = $"Product {i}'" });
            //}

            db.SaveChanges();
        }
    }
}
