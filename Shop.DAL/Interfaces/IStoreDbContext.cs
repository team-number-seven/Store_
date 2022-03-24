using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Store.DAL.Entities;

namespace Store.DAL.Interfaces
{
    public interface IStoreDbContext
    {
        DbSet<Brand> Brands { get; set; }
        DbSet<ImageFormat> ImageFormats { get; set; }
        DbSet<Item> Items { get; set; }
        DbSet<Logo> Logos { get; set; }
        DbSet<MainItemImage> MainImages { get; set; }
        DbSet<AgeTypeItem> AgeTypes { get; set; }
        DbSet<BusinessCharacteristicItem> BusinessCharacteristicItems { get; set; }
        DbSet<CharacteristicItem> CharacteristicItems { get; set; }
        DbSet<Color> Colors { get; set; }
        DbSet<Country> Countries { get; set; }
        DbSet<Gender> Genders { get; set; }
        DbSet<ItemType> ItemTypes { get; set; }
        DbSet<Manufacturer> Manufacturers { get; set; }
        DbSet<SeasonItem> SeasonItems { get; set; }
        DbSet<SubItemType> SubItemTypes { get; set; }
        DbSet<SecondaryItemImage> SecondaryImages { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<WarehouseItem> WarehouseItems { get; set; }
        public DbSet<SizeItem> SizeItems { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new());

        EntityEntry<TEntity> Entry<TEntity>(TEntity entity)
            where TEntity : class;
    }
}