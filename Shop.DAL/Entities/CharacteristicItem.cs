using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.DAL.Interfaces;

namespace Store.DAL.Entities
{
    public class CharacteristicItem:IBaseEntity
    {
        public Guid Id { get; set; }

        public Color Color { get; set; }
        public Guid ColorId { get; set; }

        public SizeItem SizeItem { get; set; }
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


    }
}
