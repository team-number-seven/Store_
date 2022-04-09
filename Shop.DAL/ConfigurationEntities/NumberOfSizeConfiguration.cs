using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.DAL.Entities;

namespace Store.DAL.ConfigurationEntities
{
    public class NumberOfSizeConfiguration : IEntityTypeConfiguration<NumberOfSize>
    {
        public void Configure(EntityTypeBuilder<NumberOfSize> builder)
        {
            builder.HasKey(s => s.Id);

            builder.ToTable("NumberOfSizes");

            builder
                .HasOne(s => s.Characteristic)
                .WithMany(c => c.ItemCountSizes)
                .HasForeignKey(s => s.CharacteristicItemId);

            builder
                .HasOne(s => s.Size)
                .WithMany(s => s.ItemCountSizes)
                .HasForeignKey(s => s.SizeTypeItemId);
        }
    }
}