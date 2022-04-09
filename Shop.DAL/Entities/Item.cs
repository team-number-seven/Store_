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


        public virtual Characteristic Characteristic { get; set; }
        public Guid CharacteristicItemId { get; set; }

        public virtual Brand Brand { get; set; }
        public Guid BrandId { get; set; }

        public virtual IEnumerable<Image> Images { get; set; }

        public virtual IEnumerable<User> BagUsers { get; set; }

        public virtual IEnumerable<User> FavoriteUsers { get; set; }
        public Guid Id { get; set; }
    }
}