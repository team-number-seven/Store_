using System;
using System.Collections.Generic;

namespace Shop.DAL.Entities
{
    public class Brand:BaseEntity
    {
        public string Title { get; set; }
        
        public List<Item> Items { get; set; }

        public Logo Logo { get; set; }
        public Guid LogoId { get; set; }
    }
}