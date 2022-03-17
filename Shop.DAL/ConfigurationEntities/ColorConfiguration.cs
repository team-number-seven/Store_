﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.ConfigurationEntities
{
    public class ColorConfiguration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.ToTable("Colors").HasKey(c => c.Id);
            builder.HasIndex(c => c.Title).IsUnique();

            builder.Property(c => c.Title).IsRequired().HasMaxLength(50);
            builder.HasMany(c => c.Items).WithOne(i => i.Color).HasForeignKey(i => i.ColorId);
        }
    }
}
