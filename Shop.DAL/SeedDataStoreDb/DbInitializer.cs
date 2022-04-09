using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Store.DAL.Entities;

namespace Store.DAL.SeedDataStoreDb
{
    public static class DbInitializer
    {
        public static async Task<bool> Initialize(StoreDbContext context)
        {
            return await context.Database.EnsureCreatedAsync();
        }

        public static async Task InitializeCountries(StoreDbContext context, string pathTxt)
        {
            var countries = new List<Country>();
            using (var reader = new StreamReader(pathTxt))
            {
                string name;
                while ((name = await reader.ReadLineAsync()) is not null)
                    countries.Add(new Country {Id = Guid.NewGuid(), Name = name});
            }

            await context.Countries.AddRangeAsync(countries);
            await context.SaveChangesAsync();
        }

        public static async Task InitializeColors(StoreDbContext context, string pathTxt)
        {
            var colors = new List<Color>();
            using (var reader = new StreamReader(pathTxt))
            {
                string name;
                while ((name = await reader.ReadLineAsync()) is not null)
                    colors.Add(new Color {Id = Guid.NewGuid(), Title = name});
            }

            await context.Colors.AddRangeAsync(colors);
            await context.SaveChangesAsync();
        }

        public static async Task InitializeImageFormats(StoreDbContext context, string pathTxt)
        {
            var formats = new List<ImageFormat>();
            using (var reader = new StreamReader(pathTxt))
            {
                string format;
                while ((format = await reader.ReadLineAsync()) is not null)
                    formats.Add(new ImageFormat {Id = Guid.NewGuid(), Format = format});
            }

            await context.ImageFormats.AddRangeAsync(formats);
            await context.SaveChangesAsync();
        }

        public static async Task InitializeItemTypeAndSizesAndSubItemTypes(StoreDbContext context, string typeName,
            string pathTxtSizes, string pathTxtSubItemTypes)
        {
            var itemType = new ItemType {Id = Guid.NewGuid(), Title = typeName};
            var sizesType = new List<Size>();
            var subItemTypes = new List<SubType>();
            using (var reader = new StreamReader(pathTxtSizes))
            {
                string size;
                while ((size = await reader.ReadLineAsync()) is not null)
                    sizesType.Add(new Size
                        {Id = Guid.NewGuid(), ItemType = itemType, ItemTypeId = itemType.Id, Value = size});
            }

            using (var reader = new StreamReader(pathTxtSubItemTypes))
            {
                string subType;
                while ((subType = await reader.ReadLineAsync()) is not null)
                    subItemTypes.Add(new SubType
                        {Id = Guid.NewGuid(), ItemType = itemType, ItemTypeId = itemType.Id, Title = subType});
            }

            await context.ItemTypes.AddAsync(itemType);
            await context.Sizes.AddRangeAsync(sizesType);
            await context.SubTypes.AddRangeAsync(subItemTypes);
            await context.SaveChangesAsync();
        }

        public static async Task InitializeSeasonItems(StoreDbContext context, string pathTxt)
        {
            var seasons = new List<Season>();
            using (var reader = new StreamReader(pathTxt))
            {
                string season;
                while ((season = await reader.ReadLineAsync()) is not null)
                    seasons.Add(new Season {Id = Guid.NewGuid(), Title = season});
            }

            await context.Seasons.AddRangeAsync(seasons);
            await context.SaveChangesAsync();
        }

        public static async Task InitializeRoles(RoleManager<Role> roleManager, string pathTxt)
        {
            using var reader = new StreamReader(pathTxt);
            string role;
            while ((role = await reader.ReadLineAsync()) is not null)
                await roleManager.CreateAsync(new Role {Name = role});
        }

        public static async Task InitializeUsers(UserManager<User> userManager, IPasswordHasher<User> passwordHasher,
            StoreDbContext context, IConfiguration configuration)
        {
            var admin1 = new User
            {
                Email = configuration["Admin1:Email"],
                NormalizedEmail = userManager.NormalizeEmail(configuration["Admin1:Email"]),
                UserName = configuration["Admin1:UserName"],
                NormalizedUserName = userManager.NormalizeName(configuration["Admin1:UserName"]),
                PhoneNumber = configuration["Admin1:PhoneNumber"],
                Country = await context.Countries.FirstOrDefaultAsync(c => c.Name == configuration["Admin1:Country"]),
                EmailConfirmed = true
            };
            var admin2 = new User
            {
                Email = configuration["Admin2:Email"],
                NormalizedEmail = userManager.NormalizeEmail(configuration["Admin2:Email"]),
                UserName = configuration["Admin2:UserName"],
                NormalizedUserName = userManager.NormalizeName(configuration["Admin2:UserName"]),
                PhoneNumber = configuration["Admin2:PhoneNumber"],
                Country = await context.Countries.FirstOrDefaultAsync(c => c.Name == configuration["Admin2:Country"]),
                EmailConfirmed = true
            };

            admin1.PasswordHash = passwordHasher.HashPassword(admin1, configuration["Admin1:Password"]);
            admin2.PasswordHash = passwordHasher.HashPassword(admin2, configuration["Admin2:Password"]);

            await userManager.CreateAsync(admin1);
            await userManager.CreateAsync(admin2);
            await userManager.AddToRoleAsync(admin1, configuration["Admin1:Role"]);
            await userManager.AddToRoleAsync(admin2, configuration["Admin2:Role"]);
        }

        public static async Task InitializeAgeTypesItem(StoreDbContext context, string pathTxt)
        {
            var ageTypeItems = new List<AgeType>();
            using (var reader = new StreamReader(pathTxt))
            {
                string title;
                while ((title = await reader.ReadLineAsync()) is not null)
                    ageTypeItems.Add(new AgeType {Id = Guid.NewGuid(), Title = title});
            }

            await context.AgeTypes.AddRangeAsync(ageTypeItems);
            await context.SaveChangesAsync();
        }

        public static async Task InitializeGenders(StoreDbContext context, string pathTxt)
        {
            var genders = new List<Gender>();
            using (var reader = new StreamReader(pathTxt))
            {
                string gender;
                while ((gender = await reader.ReadLineAsync()) is not null)
                    genders.Add(new Gender {Id = Guid.NewGuid(), Title = gender});
            }

            await context.Genders.AddRangeAsync(genders);
            await context.SaveChangesAsync();
        }

        public static async Task InitializeBrands(StoreDbContext context, string pathTxt)
        {
            var brands = new List<Brand>();
            using var reader = new StreamReader(pathTxt);
            string brand;
            while ((brand = await reader.ReadLineAsync()) is not null)
            {
                var brandAndCountry = brand.Split("|");
                var country = await context.Countries.FirstOrDefaultAsync(c => c.Name == brandAndCountry[1]);
                brands.Add(new Brand {Country = country, CountryId = country.Id, Title = brandAndCountry[0]});
            }

            await context.Brands.AddRangeAsync(brands);
            await context.SaveChangesAsync();
        }
    }
}