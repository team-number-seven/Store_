using System.Collections.Generic;

namespace Shop.DAL.Entities
{
    public class Country:BaseEntity
    {
        public string Name { get; set; }

        public List<Item> Items { get; set; }

        public List<User> Users { get; set; }
    }
}