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
    public class SizeItemConfiguration:IEntityTypeConfiguration<SizeItem>
    {
        public void Configure(EntityTypeBuilder<SizeItem> builder)
        {
            builder
                .ToTable("Sizes")
                .HasKey(s => s.Id);

            builder
                .HasIndex(s => s.Size)
                .IsUnique();

            builder
                .Property(s => s.Size)
                .HasMaxLength(20)
                .IsRequired();

            builder
                .HasOne(s => s.ItemType)
                .WithMany(t => t.SizeItems)
                .HasForeignKey(s => s.ItemTypeId);

            builder
                .HasMany(s => s.CharacteristicItems)
                .WithOne(c => c.SizeItem)
                .HasForeignKey(c => c.SizeItemId);

        }
    }
}
