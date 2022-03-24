﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.DAL.Entities;

namespace Store.DAL.ConfigurationEntities
{
    public class SubItemTypeConfiguration : IEntityTypeConfiguration<SubItemType>
    {
        public void Configure(EntityTypeBuilder<SubItemType> builder)
        {
            builder
                .ToTable("SubItemTypes")
                .HasKey(s => s.Id);

            builder
                .HasIndex(s => s.Title)
                .IsUnique();

            builder
                .Property(s => s.Title)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .HasOne(s => s.ItemType)
                .WithMany(t => t.SubItemTypes)
                .HasForeignKey(s => s.ItemTypeId);

            builder
                .HasMany(s => s.CharacteristicItems)
                .WithOne(c => c.SubItemType)
                .HasForeignKey(c => c.SubTypeItemId);
        }
    }
}