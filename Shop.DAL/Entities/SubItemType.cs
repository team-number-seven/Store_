using Store.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace Store.DAL.Entities
{
    public class SubItemType:IBaseEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public IEnumerable<ItemType> ItemTypes{ get; set; }
    }
}
