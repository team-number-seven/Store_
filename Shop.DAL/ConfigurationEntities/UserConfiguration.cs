using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.DAL.Entities;

namespace Store.DAL.ConfigurationEntities
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users").HasKey(u => u.Id);

            builder.Ignore(u => u.AccessFailedCount);
            builder.Ignore(u => u.LockoutEnabled);
            builder.Ignore(u => u.LockoutEnd);
            builder.Ignore(u => u.TwoFactorEnabled);

            builder
                .HasIndex(u => u.PhoneNumber)
                .IsUnique();

            builder
                .Property(u => u.PhoneNumber)
                .IsRequired();

            builder
                .Property(u => u.CreateDate)
                .IsRequired()
                .HasDefaultValue(DateTime.Now);

            builder
                .HasOne(u => u.Country)
                .WithMany(c => c.Users)
                .HasForeignKey(u => u.CountryId);

            builder
                .HasMany(u => u.BagItems)
                .WithOne(b => b.User)
                .HasForeignKey(b => b.UserId);

            builder
                .HasMany(u => u.FavoriteItems)
                .WithOne(f => f.User)
                .HasForeignKey(f => f.UserId);
        }
    }
}