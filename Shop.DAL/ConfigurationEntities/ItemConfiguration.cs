using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.DAL.Entities;

namespace Store.DAL.ConfigurationEntities
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder
                .ToTable("Items")
                .HasKey(i => i.Id);

            builder
                .HasIndex(i => i.Title)
                .IsUnique();

            builder
                .Property(i => i.Title)
                .HasMaxLength(50);

            builder
                .Property(i => i.Description)
                .HasMaxLength(2000)
                .IsRequired();

            builder
                .Property(i => i.CountItem)
                .HasDefaultValue(0);

            builder.Property(i => i.CountSales)
                .HasDefaultValue(0);

            builder
                .HasOne(i => i.CharacteristicItem)
                .WithOne(c => c.Item)
                .HasForeignKey<Item>(i => i.CharacteristicItemId);

            builder
                .HasOne(i => i.BusinessCharacteristic)
                .WithOne(i => i.Item)
                .HasForeignKey<Item>(i => i.BusinessCharacteristicId);

            builder
                .HasOne(i => i.MainItemImage)
                .WithOne(i => i.Item)
                .HasForeignKey<Item>(i => i.MainItemImageId);

            builder
                .HasOne(i => i.Brand)
                .WithMany(b => b.Items)
                .HasForeignKey(b => b.BrandId);

            builder
                .HasOne(i => i.WarehouseItem)
                .WithMany(w => w.Items)
                .HasForeignKey(i => i.WarehouseItemId);


            builder
                .HasMany(i => i.SecondaryItemImages)
                .WithOne(i => i.Item)
                .HasForeignKey(i => i.ItemId);

            builder
                .HasMany(i => i.BagUsers)
                .WithMany(u => u.BagItems)
                .UsingEntity(t => t.ToTable("BagItemsUser"));

            builder
                .HasMany(i => i.FavoriteUsers)
                .WithMany(u => u.FavoriteItems)
                .UsingEntity(t => t.ToTable("FavoriteItemsUser"));
        }
    }
}