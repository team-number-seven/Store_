using System;
using Shop.DAL.Interfaces;

namespace Shop.DAL.Entities
{
    public class BagItem : IBaseEntity
    {
        public Guid Id { get; set; }

        public Item Item { get; set; }
        public Guid ItemId { get; set; }
    }
}