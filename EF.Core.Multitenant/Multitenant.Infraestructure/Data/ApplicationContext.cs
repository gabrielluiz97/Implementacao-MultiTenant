using Microsoft.EntityFrameworkCore;
using Multitenant.API.Provider;
using Multitenant.Domain;

namespace Multitenant.Infraestructure.Data
{
    public class ApplicationContext : DbContext
    {
        public readonly TenantData _tenantData;

        public ApplicationContext(DbContextOptions<ApplicationContext> options,
            TenantData tenantData)
            : base(options)
        {
            _tenantData = tenantData;   
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Product> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(_tenantData.TenantId);

            modelBuilder.SeedsInit();
        }
    }
}
