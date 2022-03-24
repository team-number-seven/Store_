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
    public class WarehouseItemConfiguration:IEntityTypeConfiguration<WarehouseItem>
    {
        public void Configure(EntityTypeBuilder<WarehouseItem> builder)
        {
            builder
                .ToTable("WarehouseItems")
                .HasKey(w => w.Id);

            builder
                .HasMany(w => w.Items)
                .WithOne(i => i.WarehouseItem)
                .HasForeignKey(i => i.WarehouseItemId);
        }
    }
}
