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
    public class LogoConfiguration:IEntityTypeConfiguration<Logo>
    {
        public void Configure(EntityTypeBuilder<Logo> builder)
        {
            builder
                .ToTable("Logos")
                .HasKey(l => l.Id);

            builder
                .HasIndex(l=>l.Path)
                .IsUnique();

            builder
                .Property(l => l.Path)
                .IsRequired();

            builder
                .HasOne(l => l.ImageFormat)
                .WithMany(f => f.Logos)
                .HasForeignKey(l => l.ImageFormatId);

            builder
                .HasOne(l => l.Brand)
                .WithOne(b => b.Logo)
                .HasForeignKey<Brand>(b => b.LogoId);
        }
    }
}
