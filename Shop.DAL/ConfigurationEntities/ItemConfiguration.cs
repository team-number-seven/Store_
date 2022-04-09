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
                .HasIndex(i => i.ArticleNumber)
                .IsUnique();

            builder
                .Property(i => i.ArticleNumber)
                .IsRequired();

            builder
                .Property(i => i.Title)
                .HasMaxLength(50);

            builder
                .Property(i => i.Price)
                .IsRequired();

            builder
                .Property(i => i.Description)
                .HasMaxLength(2000)
                .IsRequired();

            builder
                .Property(i => i.CountItem)
                .HasDefaultValue(0);

            builder.Property(i => i.NumberOfSales)
                .HasDefaultValue(0);

            builder
                .HasOne(i => i.Characteristic)
                .WithOne(c => c.Item)
                .HasForeignKey<Item>(i => i.CharacteristicItemId);

            builder
                .HasOne(i => i.Brand)
                .WithMany(b => b.Items)
                .HasForeignKey(b => b.BrandId);


            builder
                .HasMany(i => i.Images)
                .WithOne(i => i.Item)
                .HasForeignKey(i => i.ItemId);

            builder
                .HasMany(i => i.BagItems)
                .WithOne(b => b.Item)
                .HasForeignKey(b => b.ItemId);

            builder
                .HasMany(i => i.FavoriteUsers)
                .WithMany(u => u.FavoriteItems)
                .UsingEntity(t => t.ToTable("FavoriteItemsUser"));
        }
    }
}