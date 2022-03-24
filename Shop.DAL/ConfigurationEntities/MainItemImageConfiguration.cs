using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.DAL.Entities;

namespace Store.DAL.ConfigurationEntities
{
    public class MainItemImageConfiguration : IEntityTypeConfiguration<MainItemImage>
    {
        public void Configure(EntityTypeBuilder<MainItemImage> builder)
        {
            builder
                .ToTable("MainItemImages")
                .HasKey(i => i.Id);

            builder
                .HasIndex(i => i.Path)
                .IsUnique();

            builder
                .Property(i => i.Path)
                .IsRequired();

            builder
                .HasOne(i => i.Item)
                .WithOne(i => i.MainItemImage)
                .HasForeignKey<MainItemImage>(i => i.ItemId);

            builder
                .HasOne(i => i.ImageFormat)
                .WithMany(f => f.MainItemImages)
                .HasForeignKey(i => i.ImageFormatId);
        }
    }
}