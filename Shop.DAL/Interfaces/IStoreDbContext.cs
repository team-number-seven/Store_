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
        DbSet<AgeType> AgeTypes { get; set; }
        DbSet<Characteristic> Characteristics { get; set; }
        DbSet<Color> Colors { get; set; }
        DbSet<Country> Countries { get; set; }
        DbSet<Gender> Genders { get; set; }
        DbSet<ItemType> ItemTypes { get; set; }
        DbSet<Season> Seasons { get; set; }
        DbSet<SubType> SubTypes { get; set; }
        DbSet<Image> Images { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<NumberOfSize> NumberOfSizes { get; set; }
        DbSet<Size> Sizes { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<UserClaim> UserClaims { get; set; }
        DbSet<UserRole> UserRoles { get; set; }
        DbSet<UserLogin> UserLogins { get; set; }
        DbSet<RoleClaim> RoleClaims { get; set; }
        DbSet<UserToken> UserTokens { get; set; }
        DbSet<BagItem> BagItems { get; set; }

        DbSet<FavoriteItem> FavoriteItems { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new());
    }
}