using Microsoft.EntityFrameworkCore;
using Multitenant.Infraestructure.Data;

namespace Multitenant.API.Extension
{
    public static class StartUpDataBasesExtension
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
            var connectionStrings = configuration.GetSection("ConnectionStrings").GetChildren().ToList();

            return connectionStrings.Select(c=> c.Value).ToList();
        }

        private static ApplicationContext GenarateContext(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();

            optionsBuilder
                .UseNpgsql(connectionString,
                    x => x.MigrationsAssembly("Multitenant.Migration"))
                .LogTo(Console.WriteLine)
                .EnableSensitiveDataLogging();

            return new ApplicationContext(optionsBuilder.Options);
        }

    }
}
