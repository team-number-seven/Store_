using System;
using Store.DAL.Interfaces;

namespace Store.DAL.Entities
{
    public class CharacteristicItem : IBaseEntity
    {
        public Color Color { get; set; }
        public Guid ColorId { get; set; }

        public SizeTypeItem SizeTypeItem { get; set; }
        public Guid SizeItemId { get; set; }

        public AgeTypeItem AgeTypeItem { get; set; }
        public Guid AgeTypeItemId { get; set; }

        public SeasonItem SeasonItem { get; set; }
        public Guid SeasonItemId { get; set; }

        public Gender Gender { get; set; }
        public Guid GenderId { get; set; }

        public SubItemType SubItemType { get; set; }
        public Guid SubTypeItemId { get; set; }

        public ItemType ItemType { get; set; }
        public Guid ItemTypeId { get; set; }

        public Item Item { get; set; }
        public Guid Id { get; set; }
    }
}