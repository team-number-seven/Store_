using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.DAL.Entities;

namespace Store.DAL.ConfigurationEntities
{
    public class BrandConfiguration:IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder
                .ToTable("Brands")
                .HasKey(b => b.Id);

            builder
                .HasIndex(b => b.Title)
                .IsUnique();

            builder
                .Property(b => b.Title)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .HasOne(b => b.Logo)
                .WithOne(l => l.Brand)
                .HasForeignKey<Brand>(l => l.LogoId);

            builder
                .HasMany(b => b.Items)
                .WithOne(i => i.Brand)
                .HasForeignKey(i => i.BrandId);
        }
    }
}
