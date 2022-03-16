using System.Collections.Generic;

namespace Shop.DAL.Entities
{
    public class Manufacturer : BaseEntity
    {
        public string Title { get; set; }
        public List<Item> Items { get; set; }
    }
}