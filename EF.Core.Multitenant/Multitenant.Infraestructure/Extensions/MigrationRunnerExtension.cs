using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Multitenant.Infraestructure.Data;

namespace Multitenant.Infraestructure.Extensions
{
    public static class MigrationRunnerExtension
    {
        public static void RunMigrationsOnAllDataBases(this IConfigurationRoot configuration)
        {
            var connectionStrings = configuration.GetConnectionStrings();

            foreach (var connectionString in connectionStrings)
            {
                var service = GetService(configuration, connectionString);

                using (var scope = service.CreateScope())
                {
                    try
                    {
                        UpdateDatabase(scope.ServiceProvider);
                    }
                    catch (Exception ex)
                    {
                        scope.Dispose();
                    }
                }
            }
        }

        private static IServiceProvider GetService(IConfigurationRoot configuration, string connectionString)
        {
            var serviceProvider = new ServiceCollection();

            serviceProvider.AddScoped<ApplicationContext>((provider) =>
            {
                var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();

                optionsBuilder
                    .UseNpgsql(connectionString)
                    .LogTo(Console.WriteLine)
                    .EnableSensitiveDataLogging();

                return new ApplicationContext(optionsBuilder.Options);
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
