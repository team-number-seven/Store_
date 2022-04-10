using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.DAL.Entities;

namespace Store.DAL.ConfigurationEntities
{
    public class FavoriteItemConfiguration:IEntityTypeConfiguration<FavoriteItem>
    {
        public void Configure(EntityTypeBuilder<FavoriteItem> builder)
        {
            builder.ToTable("FavoriteItems");

            builder.HasKey(f => f.Id);

            builder
                .HasOne(f => f.Item)
                .WithMany(i => i.FavoriteItems)
                .HasForeignKey(f => f.ItemId);

            builder
                .HasOne(f => f.User)
                .WithMany(i => i.FavoriteItems)
                .HasForeignKey(f => f.UserId);
        }
    }
}
