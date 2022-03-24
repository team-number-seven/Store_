using System;
using System.Collections.Generic;
using Store.DAL.Interfaces;

namespace Store.DAL.Entities
{
    public class Color : IBaseEntity
    {
        public string Name { get; set; }

        public IEnumerable<CharacteristicItem> CharacteristicItems { get; set; }
        public Guid Id { get; set; }
    }
}