using System;
using System.Collections.Generic;
using Store.DAL.Interfaces;

namespace Store.DAL.Entities
{
    public class Item : IBaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public uint CountSales { get; set; }
        public uint CountItem { get; set; }


        public CharacteristicItem CharacteristicItem { get; set; }
        public Guid CharacteristicItemId { get; set; }

        public BusinessCharacteristicItem BusinessCharacteristic { get; set; }
        public Guid BusinessCharacteristicId { get; set; }

        public MainItemImage MainItemImage { get; set; }
        public Guid MainItemImageId { get; set; }

        public WarehouseItem WarehouseItem { get; set; }
        public Guid WarehouseItemId { get; set; }


        public Brand Brand { get; set; }
        public Guid BrandId { get; set; }

        public IEnumerable<SecondaryItemImage> SecondaryItemImages { get; set; }

        public IEnumerable<User> BagUsers { get; set; }

        public IEnumerable<User> FavoriteUsers { get; set; }
        public Guid Id { get; set; }
        
    }
}