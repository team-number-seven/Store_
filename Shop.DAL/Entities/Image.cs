using System.Collections.Generic;

namespace Shop.DAL.Entities
{
    public class Image:BaseEntity
    {
        public byte[] ImageData { get; set; }
        public string Format { get; set; }

        public List<Item> Items { get; set; }
    }
}