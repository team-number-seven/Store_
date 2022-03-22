using System;
using System.Collections.Generic;
using Store.DAL.Interfaces;

namespace Store.DAL.Entities
{
    public class Brand : IBaseEntity
    {
        public string Title { get; set; }

        public IEnumerable<Item> Items { get; set; }

        public Logo Logo { get; set; }
        public Guid LogoId { get; set; }
        public Guid Id { get; set; }
    }
}