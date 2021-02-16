using System;
using CarRent.CarManagement.Domain;
using CarRent.CarManagement.Infrastrucure;
using CarRent.CustomerManagement.Domain;
using CarRent.CustomerManagement.Infrastructure;
using CarRent.ReservationManagement.Domain;
using CarRent.ReservationManagement.Infrastructure;
using CarRent.Seed;
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
        public virtual DbSet<Car> Car { get; set; }
        public virtual DbSet<CarClass> CarClass { get; set; }
        public virtual DbSet<Reservation> Reservation { get; set; }

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
            modelBuilder.ApplyConfiguration(new CarConfiguration());
            modelBuilder.ApplyConfiguration(new CarClassConfiguration());
            modelBuilder.ApplyConfiguration(new ReservationConfiguration());

            modelBuilder.Entity<CarClass>().HasData(BaseSeed.CarClasses);

        }
    }
}
