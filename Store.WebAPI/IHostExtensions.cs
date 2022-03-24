﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Store.DAL;
using Store.DAL.Entities;
using Store.DAL.SeedDataStoreDb;

namespace Store.WebAPI
{
    public static class IHostExtensions
    {
        public static async Task HostConfiguration(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<StoreDbContext>();
                if (await DbInitializer.Initialize(context) is false)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogWarning("An error occurred while seeding the database.");
                    return;
                }

                var userManager = services.GetRequiredService<UserManager<User>>();
                var rolesManager = services.GetRequiredService<RoleManager<IdentityRole<Guid>>>();
                var passwordHasher = services.GetRequiredService<IPasswordHasher<User>>();
                var configuration = services.GetRequiredService<IConfiguration>();

                var mainPath = configuration["Initialize:MainPath"];
                var countriesPath = mainPath + configuration["Initialize:CountriesPath"];
                var colorsPath = mainPath + configuration["Initialize:ColorsPath"];
                var imageFormatsPath = mainPath + configuration["Initialize:ImageFormatsPath"];
                var itemTypeSizes1Path = mainPath + configuration["Initialize:ItemTypeSizes_1Path"];
                var itemSubTypes1Path = mainPath + configuration["Initialize:ItemSubTypes_1Path"];
                var itemTypeSizes2Path = mainPath + configuration["Initialize:ItemTypeSizes_2Path"];
                var itemSubTypes2Path = mainPath + configuration["Initialize:ItemSubTypes_2Path"];
                var rolesPath = mainPath + configuration["Initialize:RolesPath"];
                var ageTypesItemPath = mainPath + configuration["Initialize:AgeTypesItemPath"];
                var seasonItemsPath = mainPath + configuration["Initialize:SeasonItemsPath"];
                var itemTypeName1 = mainPath + configuration["Initialize:ItemTypeName_1"];
                var itemTypeName2 = mainPath + configuration["Initialize:ItemTypeName_2"];
                var gendersPath = mainPath + configuration["Initialize:GendersPath"];

                await DbInitializer.InitializeCountries(context, countriesPath);
                await DbInitializer.InitializeAgeTypesItem(context, ageTypesItemPath);
                await DbInitializer.InitializeColors(context, colorsPath);
                await DbInitializer.InitializeImageFormats(context, imageFormatsPath);
                await DbInitializer.InitializeItemTypeAndSizesAndSubItemTypes(context, itemTypeName1,
                    itemTypeSizes1Path, itemSubTypes1Path);
                await DbInitializer.InitializeItemTypeAndSizesAndSubItemTypes(context, itemTypeName2,
                    itemTypeSizes2Path, itemSubTypes2Path);
                await DbInitializer.InitializeRoles(rolesManager, rolesPath);
                await DbInitializer.InitializeSeasonItems(context, seasonItemsPath);
                await DbInitializer.InitializeUsers(userManager, passwordHasher, context);
                await DbInitializer.InitializeGenders(context, gendersPath);
            }
        }
    }
}