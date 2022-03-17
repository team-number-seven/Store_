using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.ConfigurationEntities
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.ToTable("Brands").HasKey(b => b.Id);
            builder.HasIndex(b => b.Title).IsUnique();

            builder.Property(b => b.Title).IsRequired().HasMaxLength(50);
            builder.HasMany(b => b.Items).WithOne(b => b.Brand).HasForeignKey(b => b.BrandId);
            builder.HasOne(b => b.Logo).WithOne(l => l.Brand).HasForeignKey<Brand>(b => b.LogoId);


        }
    }
}
