using System;
using System.Collections.Generic;
using Shop.DAL.Interfaces;

namespace Shop.DAL.Entities
{
    public class Color : IBaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<Item> Items { get; set; }
    }
}