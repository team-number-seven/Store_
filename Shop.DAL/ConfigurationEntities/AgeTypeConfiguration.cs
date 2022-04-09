using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.DAL.Entities;

namespace Store.DAL.ConfigurationEntities
{
    public class AgeTypeConfiguration : IEntityTypeConfiguration<AgeType>
    {
        public void Configure(EntityTypeBuilder<AgeType> builder)
        {
            // TODO OnDelete

            builder.ToTable("AgeTypes").HasKey(a => a.Id);

            builder
                .HasIndex(a => a.Title)
                .IsUnique();

            builder
                .Property(a => a.Title)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .HasMany(a => a.CharacteristicItems)
                .WithOne(i => i.AgeType)
                .HasForeignKey(i => i.AgeTypeItemId);
        }
    }
}