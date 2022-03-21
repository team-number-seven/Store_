using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Store.DAL.Entities;
using Store.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DAL.SeedDataStoreDb
{
    public static class DbRolesInitialazer
    {
        public static async Task InitialazeAsync(UserManager<User> userManager, RoleManager<IdentityRole<Guid>> roleManager,IStoreDbContext context, IPasswordHasher<User> userHasher)
        {
            string adminEmail = "pavell.urusov@gmail.com";
            string password = "pavel200301";


            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole<Guid>("admin"));
            }
            if (await roleManager.FindByNameAsync("user") == null)
            {
                await roleManager.CreateAsync(new IdentityRole<Guid>("user"));
            }
            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                var country = await context.Countries.FirstOrDefaultAsync(c => c.Name == "Belarus");

                User admin = new User
                { Email = adminEmail, UserName = "pavel",Country = country,CountryId = country.Id,CreateDate = DateTime.Now,
                    NormalizedEmail = userManager.NormalizeEmail(adminEmail),NormalizedUserName = userManager.NormalizeName("pavel"),PhoneNumber = "+375333226602"};
                admin.PasswordHash = userHasher.HashPassword(admin, password);

                IdentityResult result = await userManager.CreateAsync(admin);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                }
            }
        }
    }
}
