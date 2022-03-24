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
    public class SeasonItemConfiguration:IEntityTypeConfiguration<SeasonItem>
    {
        public void Configure(EntityTypeBuilder<SeasonItem> builder)
        {
            builder
                .ToTable("SeasonTypes")
                .HasKey(s => s.Id);

            builder
                .HasIndex(s => s.Title)
                .IsUnique();

            builder
                .Property(s => s.Title)
                .HasMaxLength(75)
                .IsRequired();

            builder
                .HasMany(s => s.CharacteristicItems)
                .WithOne(c => c.SeasonItem)
                .HasForeignKey(c => c.SeasonItemId);
        }
    }
}
