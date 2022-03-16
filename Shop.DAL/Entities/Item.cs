using System;
using System.Collections.Generic;

namespace Shop.DAL.Entities
{
    public class Item:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ArticleNumber { get; set; }
        public int CountItem { get; set; }

        public Gender Gender { get; set; }
        public Guid GenderId { get; set; }

        public Brand Brand { get; set; }
        public Guid BrandId { get; set; }

        public TypeItem TypeItem { get; set; }
        public Guid TypeItemId { get; set; }

        public Color Color { get; set; }
        public Guid ColorId { get; set; }

        public Country Country { get; set; }
        public Guid ComutryId { get; set; }

        public Manufacturer Manufacturer { get; set; }
        public Guid ManufacturerId { get; set; }

        public List<Image> Images { get; set; }

    }
}
