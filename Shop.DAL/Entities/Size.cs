using System;
using System.Collections.Generic;

namespace Store.DAL.Entities
{
    public class Size
    {
        public Guid Id { get; set; }

        public string Value { get; set; }
        public string Standard { get; set; }

        public virtual IEnumerable<NumberOfSize> ItemCountSizes { get; set; }
        public virtual IEnumerable<BagItem> BagItems { get; set; }

        public virtual ItemType ItemType { get; set; }
        public Guid ItemTypeId { get; set; }
    }
}