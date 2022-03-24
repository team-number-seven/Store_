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
    public class SecondaryItemImageConfiguration:IEntityTypeConfiguration<SecondaryItemImage>
    {
        public void Configure(EntityTypeBuilder<SecondaryItemImage> builder)
        {
            builder
                .ToTable("SecondaryItemImages")
                .HasKey(i => i.Id);

            builder
                .HasIndex(i => i.Path)
                .IsUnique();

            builder
                .Property(i => i.Path)
                .IsRequired();


            builder
                .HasOne(i => i.Item)
                .WithMany(i => i.SecondaryItemImages)
                .HasForeignKey(i => i.ItemId);

            builder
                .HasOne(i => i.ImageFormat)
                .WithMany(f => f.SecondaryItemImage)
                .HasForeignKey(i => i.ImageFormatId);
        }
    }
}
