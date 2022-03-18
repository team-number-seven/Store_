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
                .HasIndex(i => i.ArticleNumber)
                .IsUnique();

            builder
                .Property(i => i.Title)
                .IsRequired()
                .HasMaxLength(70);

            builder.Property(i => i.Description);

            builder.Property(i => i.CountItem);

            builder
                .HasOne(i => i.Gender)
                .WithMany(g => g.Items)
                .HasForeignKey(i => i.GenderId);

            builder
                .HasOne(i => i.Brand)
                .WithMany(b => b.Items)
                .HasForeignKey(i => i.BrandId);

            builder
                .HasMany(i => i.TypeItems)
                .WithMany(t => t.Items
                ).UsingEntity(e => e.ToTable("ItemTypeItem"));

            builder
                .HasOne(i => i.Color)
                .WithMany(c => c.Items)
                .HasForeignKey(i => i.ColorId);

            builder
                .HasOne(i => i.Country)
                .WithMany(c => c.Items)
                .HasForeignKey(i => i.CountryId);

            builder
                .HasOne(i => i.AgeType)
                .WithMany(a => a.Items)
                .HasForeignKey(i => i.AgeTypeId);

            builder
                .HasOne(i => i.Manufacturer)
                .WithMany(m => m.Items)
                .HasForeignKey(i => i.ManufacturerId);

            builder
                .HasMany(i => i.Images)
                .WithMany(i => i.Items)
                .UsingEntity(e => e.ToTable("ImageItem"));

            builder
                .HasMany(i => i.BagUsers)
                .WithMany(u => u.BagItems)
                .UsingEntity(u => u.ToTable("BagItemUser"));

            builder
                .HasMany(i => i.FavoriteUsers)
                .WithMany(u => u.FavoriteItems)
                .UsingEntity(u => u.ToTable("FavoriteItemUser"));

        }
    }
}