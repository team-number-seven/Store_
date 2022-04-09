using System;
using System.Collections.Generic;
using Store.DAL.Interfaces;

namespace Store.DAL.Entities
{
    public class Characteristic : IBaseEntity
    {
        public virtual Color Color { get; set; }
        public Guid ColorId { get; set; }

        public virtual IEnumerable<NumberOfSize> ItemCountSizes { get; set; }

        public virtual AgeType AgeType { get; set; }
        public Guid AgeTypeItemId { get; set; }

        public virtual Season Season { get; set; }
        public Guid SeasonItemId { get; set; }

        public virtual Gender Gender { get; set; }
        public Guid GenderId { get; set; }

        public virtual SubType SubType { get; set; }
        public Guid SubTypeItemId { get; set; }

        public virtual ItemType ItemType { get; set; }
        public Guid ItemTypeId { get; set; }

        public virtual Item Item { get; set; }
        public Guid Id { get; set; }
    }
}