using CarRent.CarManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRent.CarManagement.Infrastrucure
{
    public class CarClassConfiguration : IEntityTypeConfiguration<CarClass>
    {
        public void Configure(EntityTypeBuilder<CarClass> builder)
        {
            builder.ToTable("carclass");
            builder.Property(x => x.Description).HasColumnName("description").IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Price).HasColumnName("price").HasColumnType("decimal");
            builder.HasMany(x => x.Cars).WithOne(x => x.CarClass).IsRequired(false);
        }
    }
}
