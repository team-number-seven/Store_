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
    public class ItemTypeConfiguration : IEntityTypeConfiguration<ItemType>
    {
        public void Configure(EntityTypeBuilder<ItemType> builder)
        {
            builder
                .HasKey(t => t.Id);

            builder
                .HasIndex(t => t.Title)
                .IsUnique();

            builder
                .Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .HasOne(t => t.SubItemType)
                .WithMany(sb => sb.ItemTypes)
                .HasForeignKey(t => t.SubItemTypeId);
        }
    }
}
