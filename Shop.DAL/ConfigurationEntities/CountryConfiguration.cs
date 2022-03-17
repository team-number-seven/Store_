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
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Countries").HasKey(c => c.Id);
            builder.HasIndex(c => c.Name).IsUnique();

            builder.Property(c => c.Name).IsRequired().HasMaxLength(75);

            builder.HasMany(c => c.Items).WithOne(i => i.Country).HasForeignKey(i => i.CountryId);
        }
    }
}
