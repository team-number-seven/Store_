using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.ConfigurationEntities
{
    public class AgeTypeConfiguration : IEntityTypeConfiguration<AgeType>
    {
        public void Configure(EntityTypeBuilder<AgeType> builder)
        {
            builder.ToTable("AgeTypes").HasKey(at => at.Id);
            builder.HasIndex(at => at.Title).IsUnique();

            builder.Property(at => at.Title).IsRequired().HasMaxLength(50);
            builder.HasMany(at => at.Items).WithOne(i => i.AgeType).HasForeignKey(fk => fk.AgeTypeId);
        }
    }
}
