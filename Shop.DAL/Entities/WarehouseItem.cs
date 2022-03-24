using System;
using System.Collections.Generic;
using Store.DAL.Interfaces;

namespace Store.DAL.Entities
{
    public class WarehouseItem : IBaseEntity
    {
        public IEnumerable<Item> Items { get; set; }
        public Guid Id { get; set; }
    }
}