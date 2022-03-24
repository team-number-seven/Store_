using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.DAL.Entities;

namespace Store.DAL.ConfigurationEntities
{
    public class CharacteristicItemConfiguration : IEntityTypeConfiguration<CharacteristicItem>
    {
        public void Configure(EntityTypeBuilder<CharacteristicItem> builder)
        {
            builder
                .ToTable("CharacteristicItems")
                .HasKey(c => c.Id);

            builder
                .HasOne(c => c.Color)
                .WithMany(c => c.CharacteristicItems)
                .HasForeignKey(c => c.ColorId);

            builder
                .HasOne(c => c.AgeTypeItem)
                .WithMany(a => a.CharacteristicItems)
                .HasForeignKey(c => c.AgeTypeItemId);

            builder
                .HasOne(c => c.SeasonItem)
                .WithMany(s => s.CharacteristicItems)
                .HasForeignKey(c => c.SeasonItemId);

            builder
                .HasOne(c => c.Gender)
                .WithMany(g => g.CharacteristicItems)
                .HasForeignKey(c => c.GenderId);

            builder
                .HasOne(c => c.SizeTypeItem)
                .WithMany(s => s.CharacteristicItems)
                .HasForeignKey(c => c.SizeItemId);

            builder
                .HasOne(c => c.SubItemType)
                .WithMany(t => t.CharacteristicItems)
                .HasForeignKey(c => c.SubTypeItemId);

            builder
                .HasOne(c => c.ItemType)
                .WithMany(t => t.CharacteristicItems)
                .HasForeignKey(c => c.ItemTypeId);

            builder
                .HasOne(c => c.Item)
                .WithOne(i => i.CharacteristicItem)
                .HasForeignKey<Item>(i => i.CharacteristicItemId);
        }
    }
}