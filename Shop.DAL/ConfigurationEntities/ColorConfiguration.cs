using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.DAL.Entities;

namespace Store.DAL.ConfigurationEntities
{
    public class ColorConfiguration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder
                .ToTable("Colors")
                .HasKey(c => c.Id);

            builder
                .HasIndex(c => c.Title)
                .IsUnique();

            builder
                .Property(c => c.Title)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .HasMany(c => c.CharacteristicItems)
                .WithOne(i => i.Color)
                .HasForeignKey(i => i.ColorId);
        }
    }
}