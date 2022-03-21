using System;
using System.Collections.Generic;
using Store.DAL.Interfaces;

namespace Store.DAL.Entities
{
    public class Image : IBaseEntity
    {
        public Guid Id { get; set; }
        public string Path { get; set; }
        public string Format { get; set; }

        public IEnumerable<Item> Items { get; set; }
        
        public Item MainItemImage { get; set; }
    }
}