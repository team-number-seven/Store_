using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.DAL.Entities;

namespace Store.DAL.ConfigurationEntities
{
    public class SeasonConfiguration : IEntityTypeConfiguration<Season>
    {
        public void Configure(EntityTypeBuilder<Season> builder)
        {
            builder
                .ToTable("Seasons")
                .HasKey(s => s.Id);

            builder
                .HasIndex(s => s.Title)
                .IsUnique();

            builder
                .Property(s => s.Title)
                .HasMaxLength(75)
                .IsRequired();

            builder
                .HasMany(s => s.CharacteristicItems)
                .WithOne(c => c.Season)
                .HasForeignKey(c => c.SeasonItemId);
        }
    }
}