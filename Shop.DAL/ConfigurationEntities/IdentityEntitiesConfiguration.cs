using Microsoft.EntityFrameworkCore;
using Store.DAL.Entities;

namespace Store.DAL.ConfigurationEntities
{
    public static class IdentityEntitiesConfiguration
    {
        public static void EntitiesConfiguration(ModelBuilder builder)
        {
            builder.Entity<Role>().ToTable("Roles");
            builder.Entity<UserRole>().ToTable("UserRoles");
            builder.Entity<UserClaim>().ToTable("UserClaims");
            builder.Entity<UserLogin>().ToTable("UserLogins");
            builder.Entity<RoleClaim>().ToTable("RoleClaims");
            builder.Entity<UserToken>().ToTable("UserTokens");
        }
    }
}