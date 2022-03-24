using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.DAL.Entities;

namespace Store.DAL.ConfigurationEntities
{
    public class BusinessCharacteristicItemConfiguration : IEntityTypeConfiguration<BusinessCharacteristicItem>
    {
        public void Configure(EntityTypeBuilder<BusinessCharacteristicItem> builder)
        {
            builder
                .ToTable("BusinessCharacteristicItems")
                .HasKey(c => c.Id);

            builder
                .HasIndex(c => c.ArticleNumber)
                .IsUnique();

            builder
                .Property(c => c.ArticleNumber)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .HasOne(c => c.Item)
                .WithOne(i => i.BusinessCharacteristic)
                .HasForeignKey<Item>(i => i.BusinessCharacteristicId);

            builder
                .HasOne(c => c.Country)
                .WithMany(c => c.BusinessCharacteristicItems)
                .HasForeignKey(c => c.CountryId);

            builder
                .HasOne(c => c.Manufacturer)
                .WithMany(m => m.BusinessCharacteristicItem)
                .HasForeignKey(c => c.ManufacturerId);
        }
    }
}