using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Store.DAL.Entities;

namespace Store.DAL.SeedDataStoreDb
{
    public static class InitCountries
    {
        public static void Init(ModelBuilder builder, string pathTxt)
        {
            List<Country> countries = new List<Country>();
            using (StreamReader reader = new StreamReader(pathTxt))
            {
                string name;
                while ((name = reader.ReadLine()) != null){ countries.Add(new Country { Id = Guid.NewGuid(), Name = name }); }
            }
            builder.Entity<Country>().HasData(countries);
        }
    }
}