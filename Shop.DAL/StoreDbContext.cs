using System;
using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using Store.DAL.Entities;
using Store.DAL.Interfaces;

namespace Store.DAL
{
    public class StoreDbContext : IdentityDbContext<User, Role, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>, IStoreDbContext
    {
        public StoreDbContext()
        {
        }

        public StoreDbContext(DbContextOptions<StoreDbContext> options)
            : base(options)
        {
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<UserClaim> UserClaims { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserLogin> UserLogins { get; set; }
        public DbSet<RoleClaim> RoleClaims { get; set; }
        public DbSet<UserToken> Tokens { get; set; }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<ImageFormat> ImageFormats { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemType> ItemTypes { get; set; }
        public DbSet<SeasonItem> SeasonItems { get; set; }
        public DbSet<SubItemType> SubItemTypes { get; set; }
        public DbSet<AgeTypeItem> AgeTypes { get; set; }
        public DbSet<CharacteristicItem> CharacteristicItems { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<ItemImage> Images { get; set; }
        public DbSet<SizeTypeItem> SizeTypeItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseNpgsql(
                "Host=localhost;Port=5555;Database=testStore;Username=postgres;Password=admin"); //the test will be deleted in the future
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            builder.Entity<Role>().ToTable("Roles");
            builder.Entity<UserRole>().ToTable("UserRoles");
            builder.Entity<UserClaim>().ToTable("UserClaims");
            builder.Entity<UserLogin>().ToTable("UserLogins");
            builder.Entity<RoleClaim>().ToTable("RoleClaims");
            builder.Entity<UserToken>().ToTable("UserTokens");
        }
    }
}