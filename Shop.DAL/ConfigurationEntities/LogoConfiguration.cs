using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.DAL.Entities;

namespace Shop.DAL.ConfigurationEntities
{
    public class LogoConfiguration:IEntityTypeConfiguration<Logo>
    {
        public void Configure(EntityTypeBuilder<Logo> builder)
        {
            builder
                .ToTable("Logos")
                .HasKey(l => l.Id);

            builder
                .HasIndex(l => l.ImageData)
                .IsUnique();

            builder
                .Property(l => l.ImageData)
                .IsRequired();

            builder.Property(l => l.Format).IsRequired();
        }
    }
}
