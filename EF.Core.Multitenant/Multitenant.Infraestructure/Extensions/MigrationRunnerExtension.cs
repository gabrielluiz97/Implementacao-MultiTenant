using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Multitenant.API.Provider;
using Multitenant.Infraestructure.Data;

namespace Multitenant.Infraestructure.Extensions
{
    public static class MigrationRunnerExtension
    {
        public static void RunMigrationsOnAllSchemas(this IConfigurationRoot configuration)
        {
            var schemas = new List<string>() { "Tenat1", "Tenant2", "Tenant3"};


            var connectionString = configuration.GetConnectionString("TenantZ");

            foreach (var schema in schemas)
            {
                var service = GetService(connectionString, schema);

                using (var scope = service.CreateScope())
                {
                    try
                    {
                        UpdateDatabase(scope.ServiceProvider);
                    }
                    catch (Exception ex)
                    {

                    }
                    finally
                    {
                        scope.Dispose();
                    }
                }
            }
        }

        private static IServiceProvider GetService(string connectionString, string schema)
        {
            var serviceProvider = new ServiceCollection();

            serviceProvider.AddScoped<ApplicationContext>((provider) =>
            {
                var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();

                optionsBuilder
                    .UseNpgsql(connectionString, x => x.MigrationsHistoryTable("__EFMigrationsHistory", schema))
                    .LogTo(Console.WriteLine)
                    .EnableSensitiveDataLogging();

                var tenant = new TenantData(schema);

                return new ApplicationContext(optionsBuilder.Options, tenant);
            });

            return serviceProvider.BuildServiceProvider();
        }

        private static void UpdateDatabase(IServiceProvider services)
        {
           using (var scope = services.CreateScope())
           {
               var db = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
               db.Database.Migrate();
           }
        }
    }
}
