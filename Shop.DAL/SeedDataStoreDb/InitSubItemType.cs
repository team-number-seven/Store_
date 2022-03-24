using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.DAL.Entities;

namespace Store.DAL.SeedDataStoreDb
{
    public static class InitSubItemTypes
    {
        public static async Task Init(ModelBuilder builder,string pathTxt)
        {
            var types = new List<SubItemType>();
            using (var reader = new StreamReader(pathTxt))
            {
                string title;
                while ((title = await reader.ReadLineAsync()) is not null)
                    types.Add(new SubItemType { Id = Guid.NewGuid(), Title = title });
            }

            builder.Entity<SubItemType>().HasData(types);
        }
    }
}
