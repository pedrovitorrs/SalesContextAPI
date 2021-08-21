using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SalesContextAPI.Domain.Entities;

namespace SalesContextAPI.Infraestructure.DBConfiguration.EFCore
{
    public class ApplicationContext : DbContext
    {
        /* Creating DatabaseContext without Dependency Injection */
        public ApplicationContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseNpgsql(DatabaseConnection.ConnectionConfiguration
                                                    .GetConnectionString("DefaultConnection"));
            }
        }

        /* Creating DatabaseContext configured outside with Dependency Injection */
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<Seller> Seller { get; set; }
    }
}
