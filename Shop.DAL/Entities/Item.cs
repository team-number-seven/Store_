using System;
using System.Collections.Generic;
using Store.DAL.Interfaces;

namespace Store.DAL.Entities
{
    public class Item : IBaseEntity
    {
        public string Title { get; set; }
        public string ArticleNumber { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public uint NumberOfSales { get; set; }
        public uint CountItem { get; set; }


        public CharacteristicItem CharacteristicItem { get; set; }
        public Guid CharacteristicItemId { get; set; }

        public Brand Brand { get; set; }
        public Guid BrandId { get; set; }

        public IEnumerable<ItemImage> Images { get; set; }

        public IEnumerable<User> BagUsers { get; set; }

        public IEnumerable<User> FavoriteUsers { get; set; }
        public Guid Id { get; set; }
        
    }
}