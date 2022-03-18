using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Multitenant.Infraestructure.Data;

namespace Multitenant.Infraestructure.Extensions
{
    public static class ConnectionStringExtension
    {
        public static IList<string> GetConnectionStrings(this IConfigurationRoot configuration)
        {
            var connectionStrings = configuration.GetSection("ConnectionStrings").GetChildren().ToList();

            return connectionStrings.Select(c=> c.Value).ToList();
        }
    }
}
