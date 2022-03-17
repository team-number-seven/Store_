using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.DAL.Entities;

namespace Shop.DAL.ConfigurationEntities
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users").HasKey(u => u.Id);

            builder
                .Property(u => u.CreateDate)
                .IsRequired();

            builder
                .HasOne(u => u.Country)
                .WithMany(c => c.Users)
                .HasForeignKey(u => u.CountryId);

            builder
                .HasMany(u => u.BagItems)
                .WithMany(i => i.BagUsers)
                .UsingEntity(u => u.ToTable("BagItemUser"));

            builder
                .HasMany(u => u.FavoriteItems)
                .WithMany(i => i.FavoriteUsers)
                .UsingEntity(u => u.ToTable("FavoriteItemUser"));
        }
    }
}