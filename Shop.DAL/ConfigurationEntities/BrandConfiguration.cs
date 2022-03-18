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
                .IsRequired()
                .HasMaxLength(50)
                .IsRequired();

            builder
                .HasMany(b => b.Items)
                .WithOne(b => b.Brand)
                .HasForeignKey(b => b.BrandId);

            builder
                .HasOne(b => b.Logo)
                .WithOne(l => l.Brand)
                .HasForeignKey<Brand>(b => b.LogoId);
        }
    }
}