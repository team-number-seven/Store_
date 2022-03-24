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
            builder.Ignore(u => u.EmailConfirmed);
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
                .WithMany(i => i.BagUsers)
                .UsingEntity(u => u.ToTable("BagItemsUser"));

            builder
                .HasMany(u => u.FavoriteItems)
                .WithMany(i => i.FavoriteUsers)
                .UsingEntity(u => u.ToTable("FavoriteItemsUser"));
        }
    }
}