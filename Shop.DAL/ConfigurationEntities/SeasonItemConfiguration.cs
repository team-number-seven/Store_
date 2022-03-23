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
    public class SeasonItemConfiguration : IEntityTypeConfiguration<SeasonItem>
    {
        public void Configure(EntityTypeBuilder<SeasonItem> builder)
        {
            builder.HasKey(s => s.Id);

            builder.HasIndex(s => s.Title).IsUnique();

            builder.Property(s => s.Title).IsRequired();

            builder.HasMany(s=>s.Items).WithOne(i=>i.sea)
        }
    }
}
