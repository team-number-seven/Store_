using System;
using System.Collections.Generic;
using Store.DAL.Interfaces;

namespace Store.DAL.Entities
{
    public class Brand : IBaseEntity
    {
        public string Title { get; set; }
        public virtual Country Country { get; set; }
        public Guid CountryId { get; set; }

        public virtual IEnumerable<Item> Items { get; set; }

        public Guid Id { get; set; }
    }
}