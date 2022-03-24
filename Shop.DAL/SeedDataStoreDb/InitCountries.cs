﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.DAL.Entities;

namespace Store.DAL.SeedDataStoreDb
{
    public static class InitCountries
    {
        public static async Task Init(ModelBuilder builder, string pathTxt)
        {
            var countries = new List<Country>();
            using (var reader = new StreamReader(pathTxt))
            {
                string name;
                while ((name = await reader.ReadLineAsync()) is not null)
                    countries.Add(new Country {Id = Guid.NewGuid(), Name = name});
            }

            builder.Entity<Country>().HasData(countries);
        }
    }
}