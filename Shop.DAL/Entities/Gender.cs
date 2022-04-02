using System;
using System.Collections.Generic;
using Store.DAL.Interfaces;

namespace Store.DAL.Entities
{
    public class Gender : IBaseEntity
    {
        public string Title { get; set; }
        public virtual IEnumerable<CharacteristicItem> CharacteristicItems { get; set; }
        public Guid Id { get; set; }
    }
}