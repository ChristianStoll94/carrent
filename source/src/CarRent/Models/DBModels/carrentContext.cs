using System;
using CarRent.CustomerManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;

namespace CarRent.Models.DBModels
{
    public partial class carrentContext : DbContext
    {
        public carrentContext()
        {
        }

        public carrentContext(DbContextOptions<carrentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=host.docker.internal;Port=3306;User=root;Password=Vujura46!;Database=carrent")
                    .UseLoggerFactory(
                        LoggerFactory.Create(b => b.AddConsole().AddFilter(level => level >= LogLevel.Information)))
                    .EnableSensitiveDataLogging().EnableDetailedErrors();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());

        }
    }
}
