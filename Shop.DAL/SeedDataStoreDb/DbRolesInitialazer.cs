using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Store.DAL.Entities;
using Store.DAL.Interfaces;

namespace Store.DAL.SeedDataStoreDb
{
    public static class DbRolesInitialazer
    {
        public static async Task InitialazeAsync(UserManager<User> userManager,
            RoleManager<IdentityRole<Guid>> roleManager, IStoreDbContext context, IPasswordHasher<User> userHasher)
        {
            var adminEmail = "pavell.urusov@gmail.com";
            var password = "pavel200301";


            if (await roleManager.FindByNameAsync("Administrator") == null)
                await roleManager.CreateAsync(new IdentityRole<Guid>("Administrator"));
            if (await roleManager.FindByNameAsync("User") == null)
                await roleManager.CreateAsync(new IdentityRole<Guid>("User"));
            if (await roleManager.FindByNameAsync("Manager") == null)
                await roleManager.CreateAsync(new IdentityRole<Guid>("Manager"));
            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                var country = await context.Countries.FirstOrDefaultAsync(c => c.Name == "Belarus");

                var admin = new User
                {
                    Email = adminEmail, UserName = "pavel", Country = country, CountryId = country.Id,
                    CreateDate = DateTime.Now,
                    NormalizedEmail = userManager.NormalizeEmail(adminEmail),
                    NormalizedUserName = userManager.NormalizeName("pavel"), PhoneNumber = "+375333226602"
                };
                admin.PasswordHash = userHasher.HashPassword(admin, password);

                var result = await userManager.CreateAsync(admin);
                if (result.Succeeded) await userManager.AddToRoleAsync(admin, "Administrator");
            }
        }
    }
}