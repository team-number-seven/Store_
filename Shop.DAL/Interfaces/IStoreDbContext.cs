﻿using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Store.DAL.Entities;

namespace Store.DAL.Interfaces
{
    public interface IStoreDbContext
    {
        DbSet<AgeType> AgeTypes { get; set; }
        DbSet<Brand> Brands { get; set; }
        DbSet<Color> Colors { get; set; }
        DbSet<Country> Countries { get; set; }
        DbSet<Gender> Genders { get; set; }
        DbSet<Image> Images { get; set; }
        DbSet<Item> Items { get; set; }
        DbSet<Logo> Logos { get; set; }
        DbSet<Manufacturer> Manufacturers { get; set; }
        DbSet<TypeItem> TypeItems { get; set; }
        DbSet<User> Users { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new());

        EntityEntry<TEntity> Entry<TEntity>(TEntity entity)
            where TEntity : class;
    }
}