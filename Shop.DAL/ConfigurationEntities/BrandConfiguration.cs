using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.DAL.Entities;

namespace Store.DAL.ConfigurationEntities
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder
                .ToTable("Brands")
                .HasKey(b => b.Id);

            builder
                .HasIndex(b => b.Title)
                .IsUnique();

            builder
                .Property(b => b.Title)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .HasOne(b => b.Country)
                .WithMany(c => c.Brands)
                .HasForeignKey(b => b.CountryId);

            builder
                .HasMany(b => b.Items)
                .WithOne(i => i.Brand)
                .HasForeignKey(i => i.BrandId);
        }
    }
}