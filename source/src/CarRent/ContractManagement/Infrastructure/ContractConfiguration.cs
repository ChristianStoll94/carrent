using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRent.ContractManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRent.ContractManagement.Infrastructure
{
    public class ContractConfiguration : IEntityTypeConfiguration<Contract>
    {
        public void Configure(EntityTypeBuilder<Contract> builder)
        {
            builder.ToTable("contract");
            builder.Property(x => x.Id).HasColumnName("id").IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.ReservationId).HasColumnName("reservationid").IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Price).HasColumnName("price").HasColumnType("decimal");
            builder.Property(x => x.PickupDate).HasColumnName("pickupdate").HasColumnType("datetime");
            builder.Property(x => x.StartDate).HasColumnName("startdate").HasColumnType("datetime");
            builder.Property(x => x.EndDate).HasColumnName("enddate").HasColumnType("datetime");
            builder.HasOne(x => x.Car).WithMany(x => x.Contracts).IsRequired();
            builder.HasOne(x => x.Customer).WithMany(x => x.Contracts).IsRequired();

        }
    }
}
