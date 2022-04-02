using System;
using System.Collections.Generic;
using Store.DAL.Interfaces;

namespace Store.DAL.Entities
{
    public class SubItemType : IBaseEntity
    {
        public string Title { get; set; }

        public virtual ItemType ItemType { get; set; }
        public Guid ItemTypeId { get; set; }

        public virtual IEnumerable<CharacteristicItem> CharacteristicItems { get; set; }
        public Guid Id { get; set; }
    }
}