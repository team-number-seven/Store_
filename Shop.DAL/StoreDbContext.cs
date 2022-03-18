using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Store.DAL.Entities;
using Store.DAL.Interfaces;

namespace Store.DAL
{
    public class StoreDbContext : IdentityDbContext<User>, IStoreDbContext
    {
        public StoreDbContext()
        {
        }

        public StoreDbContext(DbContextOptions<StoreDbContext> options)
            : base(options)
        {
        }

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
            optionsBuilder.UseNpgsql("Host=localhost;Port=5555;Database=testStore;Username=postgres;Password=admin");//the test will be deleted in the future
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            DbInitializer<StoreDbContext>.InitializeSeedData(builder);

            base.OnModelCreating(builder);
        }
    }
}