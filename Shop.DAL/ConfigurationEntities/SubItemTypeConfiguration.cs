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
    public class SubItemTypeConfiguration : IEntityTypeConfiguration<SubItemType>
    {
        public void Configure(EntityTypeBuilder<SubItemType> builder)
        {
            builder.HasKey(sb => sb.Id);

            builder
                .HasIndex(sb => sb.Title)
                .IsUnique();
            builder
                .Property(sb => sb.Title)
                .IsRequired();

            builder
                .HasMany(sb => sb.ItemTypes)
                .WithOne(t => t.SubItemType)
                .HasForeignKey(t => t.SubItemTypeId);

        }
    }
}
