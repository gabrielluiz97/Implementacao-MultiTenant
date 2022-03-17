﻿using Microsoft.EntityFrameworkCore;
using Multitenant.API.Provider;
using Multitenant.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>().HasData(
                new Person { Id = 1, Name = "Person 1",},
                new Person { Id = 2, Name = "Person 2" },
                new Person { Id = 3, Name = "Person 3"});

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Description = "Description 1"},
                new Product { Id = 2, Description = "Description 2"},
                new Product { Id = 3, Description = "Description 3"});
        }
    }
}
