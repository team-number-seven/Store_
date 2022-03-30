using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.DAL.Entities;

namespace Store.DAL.ConfigurationEntities
{
    public class ItemImageConfiguration : IEntityTypeConfiguration<ItemImage>
    {
        public void Configure(EntityTypeBuilder<ItemImage> builder)
        {
            builder
                .ToTable("SecondaryItemImages")
                .HasKey(i => i.Id);

            builder
                .HasIndex(i => i.Path)
                .IsUnique();

            builder
                .Property(i => i.Path)
                .IsRequired();


            builder
                .HasOne(i => i.Item)
                .WithMany(i => i.Images)
                .HasForeignKey(i => i.ItemId);

            builder
                .HasOne(i => i.ImageFormat)
                .WithMany(f => f.Images)
                .HasForeignKey(i => i.ImageFormatId);
        }
    }
}