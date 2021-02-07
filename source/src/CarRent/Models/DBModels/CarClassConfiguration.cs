using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRent.CarManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRent.Models.DBModels
{
    public class CarClassConfiguration : IEntityTypeConfiguration<CarClass>
    {
        public void Configure(EntityTypeBuilder<CarClass> builder)
        {
            builder.ToTable("car");
            builder.Property(x => x.Description).HasColumnName("description").IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Price).HasColumnName("price").HasColumnType("varchar(45)");
            builder.HasMany(x => x.Cars).WithOne(x => x.CarClass).IsRequired(false);
        }
    }
}
