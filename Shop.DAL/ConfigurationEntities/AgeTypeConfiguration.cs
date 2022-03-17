using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.DAL.Entities;

namespace Shop.DAL.ConfigurationEntities
{
    public class AgeTypeConfiguration : IEntityTypeConfiguration<AgeType>
    {
        public void Configure(EntityTypeBuilder<AgeType> builder)
        {
            builder
                .ToTable("AgeTypes")
                .HasKey(at => at.Id);

            builder
                .HasIndex(at => at.Title)
                .IsUnique();

            builder
                .Property(at => at.Title)
                .IsRequired()
                .HasMaxLength(50)
                .IsRequired();

            builder
                .HasMany(at => at.Items)
                .WithOne(i => i.AgeType)
                .HasForeignKey(fk => fk.AgeTypeId);
        }
    }
}