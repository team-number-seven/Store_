using System;
using System.Collections.Generic;
using Store.DAL.Interfaces;

namespace Store.DAL.Entities
{
    public class Item : IBaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ArticleNumber { get; set; }
        public uint CountItem { get; set; }
        public uint NumberSales { get; set; }

        public Gender Gender { get; set; }
        public Guid GenderId { get; set; }

        public Brand Brand { get; set; }
        public Guid BrandId { get; set; }

        public Color Color { get; set; }
        public Guid ColorId { get; set; }

        public Country Country { get; set; }
        public Guid CountryId { get; set; }

        public AgeType AgeType { get; set; }
        public Guid AgeTypeId { get; set; }

        public Manufacturer Manufacturer { get; set; }
        public Guid ManufacturerId { get; set; }

        public MainItemImage MainItemImage { get; set; }
        public Guid MainItemImageId { get; set; }

        public IEnumerable<SecondaryItemImage> Images { get; set; }

        public ItemType ItemType { get; set; }
        public Guid ItemTypeId { get; set; }

        public SeasonItem SeasonItem { get; set; }
        public Guid SeasonItemId { get; set; }

        public IEnumerable<User> BagUsers { get; set; }

        public IEnumerable<User> FavoriteUsers { get; set; }
        public Guid Id { get; set; }
    }
}