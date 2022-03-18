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
                .HasIndex(c => c.Name)
                .IsUnique();

            builder
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsRequired();

            builder
                .HasMany(c => c.Items)
                .WithOne(i => i.Color)
                .HasForeignKey(i => i.ColorId);
        }
    }
}