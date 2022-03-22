using System;
using System.Collections.Generic;
using Store.DAL.Interfaces;

namespace Store.DAL.Entities
{
    public class Manufacturer : IBaseEntity
    {
        public string Title { get; set; }

        public IEnumerable<Item> Items { get; set; }
        public Guid Id { get; set; }
    }
}