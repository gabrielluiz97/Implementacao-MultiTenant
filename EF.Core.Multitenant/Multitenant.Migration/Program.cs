using Microsoft.Extensions.Configuration;
using Multitenant.Infraestructure.Extensions;

var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();


configuration.RunMigrationsOnAllDataBases();

