using Microsoft.EntityFrameworkCore;
using Multitenant.Infraestructure.Data;

namespace Multitenant.API.Extension
{
    public static class BuilderExtension
    {
        public static IList<ApplicationContext> GenerateContexts(this WebApplicationBuilder builder)
        {
            var connectionStrings = GetConnectionStrings(builder.Configuration);

            var contexts = new List<ApplicationContext>();

            foreach (var connectionString in connectionStrings)
            {
                var context = GenarateContext(connectionString);
                contexts.Add(context);
            };

            return contexts;
        }

        private static IList<string> GetConnectionStrings(ConfigurationManager configuration)
        {
            //TODO: Definir estratégia para capturar connections strings de forma dinâmica
            var connectionStrings = new List<string>() {
                configuration.GetConnectionString("Tenant1"),
                configuration.GetConnectionString("Tenant2"),
                configuration.GetConnectionString("Tenantz")
            };

            return connectionStrings;
        }

        private static ApplicationContext GenarateContext(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();

            optionsBuilder
                .UseNpgsql(connectionString)
                .LogTo(Console.WriteLine)
                .EnableSensitiveDataLogging();

            return new ApplicationContext(optionsBuilder.Options);
        }

    }
}
