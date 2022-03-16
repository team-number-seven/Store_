using System.Collections.Generic;

namespace Shop.DAL.Entities
{
    public class Gender:BaseEntity
    {
        public string Title { get; set; }
        public List<Item> Items { get; set; }
    }
}