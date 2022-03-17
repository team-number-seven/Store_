using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.DAL.Entities;

namespace Shop.DAL.ConfigurationEntities
{
    public class TypeItemConfiguration:IEntityTypeConfiguration<TypeItem>
    {
        public void Configure(EntityTypeBuilder<TypeItem> builder)
        {
            builder
                .ToTable("TypeItem")
                .HasKey(t => t.Id);

            builder
                .HasIndex(t => t.Title)
                .IsUnique();

            builder
                .Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .HasMany(t => t.Items).WithMany(i => i.TypeItems).UsingEntity(e => e.ToTable("ItemTypeItem"));
        }
    }
}
