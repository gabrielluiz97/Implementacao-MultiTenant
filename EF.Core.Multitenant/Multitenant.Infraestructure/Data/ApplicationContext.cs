﻿using Microsoft.EntityFrameworkCore;
using Multitenant.Domain;

namespace Multitenant.Infraestructure.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Product> Products { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedsInit();
        }
    }
}
