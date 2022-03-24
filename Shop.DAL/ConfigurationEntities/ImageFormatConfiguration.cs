using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.DAL.Entities;

namespace Store.DAL.ConfigurationEntities
{
    public class ImageFormatConfiguration : IEntityTypeConfiguration<ImageFormat>
    {
        public void Configure(EntityTypeBuilder<ImageFormat> builder)
        {
            builder
                .ToTable("ImageFormats")
                .HasKey(f => f.Id);

            builder
                .HasIndex(f => f.Format)
                .IsUnique();

            builder
                .Property(f => f.Format)
                .HasMaxLength(15);

            builder
                .HasMany(f => f.MainItemImages)
                .WithOne(i => i.ImageFormat)
                .HasForeignKey(i => i.ImageFormatId);

            builder
                .HasMany(f => f.SecondaryItemImage)
                .WithOne(i => i.ImageFormat)
                .HasForeignKey(i => i.ImageFormatId);

            builder
                .HasMany(f => f.Logos)
                .WithOne(l => l.ImageFormat)
                .HasForeignKey(l => l.ImageFormatId);
        }
    }
}