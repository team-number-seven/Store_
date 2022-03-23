using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Store.DAL.Entities;

namespace Store.DAL.SeedDataStoreDb
{
    public static class InitSeasonItem
    {
        public static void Init(ModelBuilder builder)
        {
            var formats = new List<ImageFormat>()
            {
                new ImageFormat{Format = ".png",Id = Guid.NewGuid()},
                new ImageFormat{Format = ".jpeg",Id=Guid.NewGuid()},
                new ImageFormat{Format = ".tiff",Id= Guid.NewGuid()},
                new ImageFormat{Format = ".gif",Id = Guid.NewGuid()}
            };
            builder.Entity<ImageFormat>().HasData(formats);
        }
    }
}
