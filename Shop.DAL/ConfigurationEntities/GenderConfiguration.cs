using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.DAL.Entities;

namespace Store.DAL.ConfigurationEntities
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
                .HasMaxLength(50)
                .IsRequired();

            builder
                .HasMany(g => g.CharacteristicItems)
                .WithOne(c => c.Gender)
                .HasForeignKey(c => c.GenderId);
        }
    }
}