using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.DAL.Entities;

namespace Store.DAL.Interfaces
{
    public interface IStoreDbContext
    {
        DbSet<Brand> Brands { get; set; }
        DbSet<ImageFormat> ImageFormats { get; set; }
        DbSet<Item> Items { get; set; }
        DbSet<AgeTypeItem> AgeTypes { get; set; }
        DbSet<CharacteristicItem> CharacteristicItems { get; set; }
        DbSet<Color> Colors { get; set; }
        DbSet<Country> Countries { get; set; }
        DbSet<Gender> Genders { get; set; }
        DbSet<ItemType> ItemTypes { get; set; }
        DbSet<SeasonItem> SeasonItems { get; set; }
        DbSet<SubItemType> SubItemTypes { get; set; }
        DbSet<ItemImage> Images { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<ItemCountSize> ItemCountSizes { get; set; }
        DbSet<SizeTypeItem> SizeTypeItems { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<UserClaim> UserClaims { get; set; }
        DbSet<UserRole> UserRoles { get; set; }
        DbSet<UserLogin> UserLogins { get; set; }
        DbSet<RoleClaim> RoleClaims { get; set; }
        DbSet<UserToken> Tokens { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new());
    }
}