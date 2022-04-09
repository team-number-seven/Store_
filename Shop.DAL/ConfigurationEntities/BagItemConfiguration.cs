using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.DAL.Entities;

namespace Store.DAL.ConfigurationEntities
{
    public class BagItemConfiguration : IEntityTypeConfiguration<BagItem>
    {
        public void Configure(EntityTypeBuilder<BagItem> builder)
        {
            builder
                .ToTable("BagItems");

            builder
                .HasKey(b => b.Id);

            builder
                .HasOne(b => b.Item)
                .WithMany(i => i.BagItems)
                .HasForeignKey(b => b.ItemId);

            builder
                .HasOne(b => b.Size)
                .WithMany(s => s.BagItems)
                .HasForeignKey(b => b.SizeId);

            builder
                .HasOne(b => b.User)
                .WithMany(u => u.BagItems)
                .HasForeignKey(b => b.UserId);
        }
    }
}