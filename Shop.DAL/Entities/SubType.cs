using System;
using System.Collections.Generic;
using Store.DAL.Interfaces;

namespace Store.DAL.Entities
{
    public class SubType : IBaseEntity
    {
        public string Title { get; set; }

        public virtual ItemType ItemType { get; set; }
        public Guid ItemTypeId { get; set; }

        public virtual IEnumerable<Characteristic> CharacteristicItems { get; set; }
        public Guid Id { get; set; }
    }
}