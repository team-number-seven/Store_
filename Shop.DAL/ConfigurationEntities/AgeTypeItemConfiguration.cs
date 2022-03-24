using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.DAL.Entities;

namespace Store.DAL.ConfigurationEntities
{
    public class AgeTypeItemConfiguration : IEntityTypeConfiguration<AgeTypeItem>
    {
        public void Configure(EntityTypeBuilder<AgeTypeItem> builder)
        {
            builder.ToTable("AgeTypesItem").HasKey(a => a.Id);

            builder
                .HasIndex(a => a.Title)
                .IsUnique();

            builder
                .Property(a => a.Title)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .HasMany(a => a.CharacteristicItems)
                .WithOne(i => i.AgeTypeItem)
                .HasForeignKey(i => i.AgeTypeItemId);
        }
    }
}