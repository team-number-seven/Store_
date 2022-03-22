using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.DAL.Entities;

namespace Store.DAL.ConfigurationEntities
{
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder
                .ToTable("Images")
                .HasKey(i => i.Id);

            builder
                .Property(i => i.Format)
                .HasMaxLength(20)
                .IsRequired();

            builder
                .Property(i => i.Path)
                .IsRequired();

            builder.
                HasOne(i => i.MainItemImage)
                .WithOne(i => i.MainImage)
                .HasForeignKey<Item>(i=>i.MainImageId);

            builder
                .HasMany(i => i.Items)
                .WithMany(i => i.Images)
                .UsingEntity(e => e.ToTable("ImageItem"));
        }
    }
}