using CarRent.CarManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRent.CarManagement.Infrastrucure
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.ToTable("car");
            builder.Property(x => x.Id).HasColumnName("id").IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Brand).HasColumnName("brand").HasColumnType("varchar(45)");
            builder.Property(x => x.Typ).HasColumnName("typ").HasColumnType("varchar(45)");
            builder.HasOne(x => x.CarClass).WithMany(x => x.Cars).IsRequired();
            builder.HasMany(x => x.Reservations).WithOne(x => x.Car);
        }
    }
}
