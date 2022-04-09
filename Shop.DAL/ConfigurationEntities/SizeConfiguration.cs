using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.DAL.Entities;

namespace Store.DAL.ConfigurationEntities
{
    public class SizeConfiguration : IEntityTypeConfiguration<Size>
    {
        public void Configure(EntityTypeBuilder<Size> builder)
        {
            builder
                .ToTable("Sizes")
                .HasKey(s => s.Id);

            builder
                .Property(s => s.Value)
                .HasMaxLength(20)
                .IsRequired();

            builder
                .HasOne(s => s.ItemType)
                .WithMany(t => t.SizeItems)
                .HasForeignKey(s => s.ItemTypeId);

            builder
                .HasMany(s => s.ItemCountSizes)
                .WithOne(c => c.Size)
                .HasForeignKey(c => c.SizeTypeItemId);
        }
    }
}