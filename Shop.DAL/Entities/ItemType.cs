using System;
using System.Collections.Generic;
using Store.DAL.Interfaces;

namespace Store.DAL.Entities
{
    public class ItemType : IBaseEntity
    {
        public string Title { get; set; }

        public IEnumerable<SubItemType> SubItemTypes { get; set; }
        public IEnumerable<CharacteristicItem> CharacteristicItems { get; set; }

        public IEnumerable<SizeTypeItem> SizeItems { get; set; }
        public Guid Id { get; set; }
    }
}