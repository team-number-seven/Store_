using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DAL.ConfigurationEntities
{
    public class ImageFormatConfiguration : IEntityTypeConfiguration<ImageFormat>
    {
        public void Configure(EntityTypeBuilder<ImageFormat> builder)
        {
            builder.ToTable("FormatsImage").HasKey(i => i.Id);
            builder.HasIndex(f => f.Format).IsUnique();

            builder.Property(f => f.Format).IsRequired();
            builder.HasMany(f => f.Images).WithOne(i => i.ImageFormat).HasForeignKey(i => i.ImageFormatId);
        }
    }
}
