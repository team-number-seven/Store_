using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.DAL.Entities;

namespace Shop.DAL.ConfigurationEntities
{
    public class GenderConfiguration : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder
                .ToTable("Genders")
                .HasKey(g => g.Id);

            builder
                .HasIndex(g => g.Title)
                .IsUnique();

            builder
                .Property(g => g.Title)
                .IsRequired()
                .HasMaxLength(100)
                .IsRequired();

            builder
                .HasMany(g => g.Items)
                .WithOne(i => i.Gender)
                .HasForeignKey(i => i.GenderId);
        }
    }
}