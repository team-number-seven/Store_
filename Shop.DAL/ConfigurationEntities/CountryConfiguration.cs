using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.DAL.Entities;

namespace Store.DAL.ConfigurationEntities
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder
                .ToTable("Countries")
                .HasKey(c => c.Id);

            builder
                .HasIndex(c => c.Name)
                .IsUnique();

            builder
                .Property(c => c.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .HasMany(c => c.Users)
                .WithOne(u => u.Country)
                .HasForeignKey(u => u.CountryId);

            builder
                .HasMany(c => c.Brands)
                .WithOne(c => c.Country)
                .HasForeignKey(c => c.CountryId);
        }
    }
}