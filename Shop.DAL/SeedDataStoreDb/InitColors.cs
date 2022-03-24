using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.DAL.Entities;

namespace Store.DAL.SeedDataStoreDb
{
    public static class InitColors
    {
        public static async Task Init(ModelBuilder builder, string pathTxt)
        {
            var colors = new List<Color>();
            using (var reader = new StreamReader(pathTxt))
            {
                string name;
                while ((name = await reader.ReadLineAsync()) is not null)
                    colors.Add(new Color {Id = Guid.NewGuid(), Name = name});
            }

            builder.Entity<Color>().HasData(colors);
        }
    }
}