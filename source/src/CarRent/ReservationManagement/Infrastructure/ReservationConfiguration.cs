using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRent.ReservationManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRent.ReservationManagement.Infrastructure
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.ToTable("reservation");
            builder.Property(x => x.Id).HasColumnName("id").IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Price).HasColumnName("price").HasColumnType("decimal");
            builder.Property(x => x.StartDate).HasColumnName("startdate").HasColumnType("datetime");
            builder.Property(x => x.EndDate).HasColumnName("enddate").HasColumnType("datetime");
            builder.HasOne(x => x.Car).WithMany(x => x.Reservations).IsRequired();
            builder.HasOne(x => x.Customer).WithMany(x => x.Reservations).IsRequired();

        }
    }
}
