using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.DAL.Entities;

namespace Store.DAL.ConfigurationEntities
{
    public class ManufacturerConfiguration : IEntityTypeConfiguration<Manufacturer>
    {
        public void Configure(EntityTypeBuilder<Manufacturer> builder)
        {
            builder
                .ToTable("Manufacturers")
                .HasKey(m => m.Id);

            builder
                .HasIndex(m => m.Title)
                .IsUnique();

            builder
                .Property(m => m.Title)
                .HasMaxLength(200)
                .IsRequired();

            builder
                .HasMany(m => m.BusinessCharacteristicItem)
                .WithOne(c => c.Manufacturer)
                .HasForeignKey(c => c.ManufacturerId);
        }
    }
}