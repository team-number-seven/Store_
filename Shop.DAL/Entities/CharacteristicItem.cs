using System;
using System.Collections.Generic;
using Store.DAL.Interfaces;

namespace Store.DAL.Entities
{
    public class CharacteristicItem : IBaseEntity
    {
        public virtual Color Color { get; set; }
        public Guid ColorId { get; set; }

        public virtual IEnumerable<ItemCountSize> ItemCountSizes { get; set; }

        public virtual AgeTypeItem AgeTypeItem { get; set; }
        public Guid AgeTypeItemId { get; set; }

        public virtual SeasonItem SeasonItem { get; set; }
        public Guid SeasonItemId { get; set; }

        public virtual Gender Gender { get; set; }
        public Guid GenderId { get; set; }

        public virtual SubItemType SubItemType { get; set; }
        public Guid SubTypeItemId { get; set; }

        public virtual ItemType ItemType { get; set; }
        public Guid ItemTypeId { get; set; }

        public virtual Item Item { get; set; }
        public Guid Id { get; set; }
    }
}