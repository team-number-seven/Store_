using Store.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace Store.DAL.Entities
{
    public class ItemType:IBaseEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public SubItemType SubItemType { get; set; }
        public Guid SubItemTypeId { get; set; }

        public IEnumerable<Item> Items { get; set; }
    }
}
