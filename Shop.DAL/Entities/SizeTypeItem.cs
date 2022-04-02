﻿using System;
using System.Collections.Generic;

namespace Store.DAL.Entities
{
    public class SizeTypeItem
    {
        public Guid Id { get; set; }

        public string Size { get; set; }

        public virtual IEnumerable<CharacteristicItem> CharacteristicItems { get; set; }

        public virtual ItemType ItemType { get; set; }
        public Guid ItemTypeId { get; set; }
    }
}