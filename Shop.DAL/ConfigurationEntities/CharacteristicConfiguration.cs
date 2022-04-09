using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.DAL.Entities;

namespace Store.DAL.ConfigurationEntities
{
    public class CharacteristicConfiguration : IEntityTypeConfiguration<Characteristic>
    {
        public void Configure(EntityTypeBuilder<Characteristic> builder)
        {
            builder
                .ToTable("Characteristics")
                .HasKey(c => c.Id);

            builder
                .HasOne(c => c.Color)
                .WithMany(c => c.CharacteristicItems)
                .HasForeignKey(c => c.ColorId);

            builder
                .HasOne(c => c.AgeType)
                .WithMany(a => a.CharacteristicItems)
                .HasForeignKey(c => c.AgeTypeItemId);

            builder
                .HasOne(c => c.Season)
                .WithMany(s => s.CharacteristicItems)
                .HasForeignKey(c => c.SeasonItemId);

            builder
                .HasOne(c => c.Gender)
                .WithMany(g => g.CharacteristicItems)
                .HasForeignKey(c => c.GenderId);

            builder
                .HasMany(c => c.ItemCountSizes)
                .WithOne(s => s.Characteristic)
                .HasForeignKey(s => s.CharacteristicItemId);

            builder
                .HasOne(c => c.SubType)
                .WithMany(t => t.CharacteristicItems)
                .HasForeignKey(c => c.SubTypeItemId);

            builder
                .HasOne(c => c.ItemType)
                .WithMany(t => t.CharacteristicItems)
                .HasForeignKey(c => c.ItemTypeId);

            builder
                .HasOne(c => c.Item)
                .WithOne(i => i.Characteristic)
                .HasForeignKey<Item>(i => i.CharacteristicItemId);
        }
    }
}