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
    public class UserTokenConfiguration:IEntityTypeConfiguration<UserToken>
    {
        public void Configure(EntityTypeBuilder<UserToken> builder)
        {
            builder.ToTable("UserRefreshTokens");
            builder.Property(t => t.Expire).IsRequired()
                .HasDefaultValue(((DateTimeOffset) DateTime.Now.AddDays(60)).ToUnixTimeSeconds().ToString());
        }
    }
}
