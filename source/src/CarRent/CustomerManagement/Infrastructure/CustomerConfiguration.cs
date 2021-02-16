using CarRent.CustomerManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRent.CustomerManagement.Infrastructure
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("customer");
            builder.Property(x => x.Id).HasColumnName("id").IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasColumnName("name").HasColumnType("varchar(45)");
            builder.Property(x => x.Address).HasColumnName("address").HasColumnType("varchar(45)");
            builder.HasMany(x => x.Reservations).WithOne(x => x.Customer);
        }
    }
}
