using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.DAL.Entities;

namespace Store.DAL.SeedDataStoreDb
{
    public static class InitItemType
    {
        public static void Init(ModelBuilder builder)
        {
            var types = new List<ItemType>()
            {
                new ItemType{Title = ".png",Id = Guid.NewGuid()},
                new ItemType{Title = ".jpeg",Id=Guid.NewGuid()},
                new ItemType{Title = ".tiff",Id= Guid.NewGuid()},
                new ItemType{Title = ".gif",Id = Guid.NewGuid()}
            };
            builder.Entity<ItemType>().HasData(types);
        }
    }
}
