using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.DAL.Entities;

namespace Store.DAL.ConfigurationEntities
{
    public class SizeItemConfiguration : IEntityTypeConfiguration<SizeTypeItem>
    {
        public void Configure(EntityTypeBuilder<SizeTypeItem> builder)
        {
            builder
                .ToTable("Sizes")
                .HasKey(s => s.Id);

            builder
                .HasIndex(s => s.Size)
                .IsUnique();

            builder
                .Property(s => s.Size)
                .HasMaxLength(20)
                .IsRequired();

            builder
                .HasOne(s => s.ItemType)
                .WithMany(t => t.SizeItems)
                .HasForeignKey(s => s.ItemTypeId);

            builder
                .HasMany(s => s.CharacteristicItems)
                .WithOne(c => c.SizeTypeItem)
                .HasForeignKey(c => c.SizeItemId);
        }
    }
}