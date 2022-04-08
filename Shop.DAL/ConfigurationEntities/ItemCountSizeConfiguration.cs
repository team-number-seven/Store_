using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.DAL.Entities;

namespace Store.DAL.ConfigurationEntities
{
    public class ItemCountSizeConfiguration:IEntityTypeConfiguration<ItemCountSize>
    {
        public void Configure(EntityTypeBuilder<ItemCountSize> builder)
        {
            builder.HasKey(s => s.Id);

            builder
                .HasOne(s => s.CharacteristicItem)
                .WithMany(c => c.ItemCountSizes)
                .HasForeignKey(s => s.CharacteristicItemId);

            builder
                .HasOne(s => s.SizeTypeItem)
                .WithMany(s => s.ItemCountSizes)
                .HasForeignKey(s => s.SizeTypeItemId);
        }
    }
}
