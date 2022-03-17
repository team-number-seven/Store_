using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop.DAL.Entities;
using Shop.DAL.Interfaces;

namespace Shop.DAL
{
    public static class DbInitializer<T> 
        where T: IStoreDbContext
    {
        public static void Initialize(StoreDbContext context)
        {
            context.Database.EnsureCreated();
        }

        public static void InitializeSeedData(ModelBuilder builder)
        {
            //init data...
            //where to save file paths???
        }
    }
}
