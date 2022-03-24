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
    public class ItemTypeConfiguration:IEntityTypeConfiguration<ItemType>
    {
        public void Configure(EntityTypeBuilder<ItemType> builder)
        {
            builder
                .ToTable("ItemTypes")
                .HasKey(t => t.Id);

            builder
                .HasIndex(c => c.Title)
                .IsUnique();

            builder
                .Property(c => c.Title)
                .IsRequired();

            builder
                .HasMany(c => c.SubItemTypes)
                .WithOne(t => t.ItemType)
                .HasForeignKey(t => t.ItemTypeId);

            builder
                .HasMany(c => c.SizeItems)
                .WithOne(s => s.ItemType)
                .HasForeignKey(s => s.ItemTypeId);

            builder
                .HasMany(c => c.CharacteristicItems)
                .WithOne(c => c.ItemType)
                .HasForeignKey(c => c.ItemTypeId);
        }
    }
}
