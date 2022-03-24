using System;
using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Store.DAL.Entities;
using Store.DAL.Interfaces;

namespace Store.DAL
{
    public class StoreDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>, IStoreDbContext
    {
        public StoreDbContext()
        {
        }

        public StoreDbContext(DbContextOptions<StoreDbContext> options)
            : base(options)
        {
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<ImageFormat> ImageFormats { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Logo> Logos { get; set; }
        public DbSet<ItemType> ItemTypes { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<SeasonItem> SeasonItems { get; set; }
        public DbSet<SubItemType> SubItemTypes { get; set; }
        public DbSet<MainItemImage> MainImages { get; set; }
        public DbSet<AgeTypeItem> AgeTypes { get; set; }
        public DbSet<BusinessCharacteristicItem> BusinessCharacteristicItems { get; set; }
        public DbSet<CharacteristicItem> CharacteristicItems { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<SecondaryItemImage> SecondaryImages { get; set; }
        public DbSet<WarehouseItem> WarehouseItems { get; set; }
        public DbSet<SizeTypeItem> SizeTypeItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(
                "Host=localhost;Port=5555;Database=testStore;Username=postgres;Password=admin"); //the test will be deleted in the future
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}