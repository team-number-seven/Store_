using System;
using Store.DAL.Interfaces;

namespace Store.DAL.Entities
{
    public class BusinessCharacteristicItem : IBaseEntity
    {
        public string ArticleNumber { get; set; }

        public Manufacturer Manufacturer { get; set; }
        public Guid ManufacturerId { get; set; }

        public Item Item { get; set; }
        public Guid Id { get; set; }
    }
}