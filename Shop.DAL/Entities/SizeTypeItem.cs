using System;
using System.Collections.Generic;

namespace Store.DAL.Entities
{
    public class SizeTypeItem
    {
        public Guid Id { get; set; }

        public string Size { get; set; }
        public string Description { get; set; }

        public IEnumerable<CharacteristicItem> CharacteristicItems { get; set; }

        public ItemType ItemType { get; set; }
        public Guid ItemTypeId { get; set; }
    }
}