using Microsoft.EntityFrameworkCore;
using Store.DAL.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DAL.SeedDataStoreDb
{
    public static class InitColors
    {
        public static void Init(ModelBuilder builder, string pathTxt)
        {
            List<Color> colors = new List<Color>();
            using (StreamReader reader = new StreamReader(pathTxt))
            {
                string name;
                while ((name = reader.ReadLine()) != null) { colors.Add(new Color { Id = Guid.NewGuid(), Name = name }); }
            }
            builder.Entity<Color>().HasData(colors);
        }
    }
}
