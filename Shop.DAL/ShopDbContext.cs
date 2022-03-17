using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shop.DAL.Entities;

namespace Shop.DAL
{
    public class ShopDbContext:IdentityDbContext<User>
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options)
            :base(options){}

        public DbSet<AgeType> AgeTypes { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Logo> Logos { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<TypeItem> TypeItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
