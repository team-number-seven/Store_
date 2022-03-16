using System;
using System.Collections.Generic;
using Shop.DAL.Interfaces;

namespace Shop.DAL.Entities
{
    public class Item : IBaseEntity
    {
        public Guid Id { get; set; }
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
        public Guid CountryId { get; set; }

        public AgeType AgeType { get; set; }
        public Guid AgeTypeId { get; set; }

        public Manufacturer Manufacturer { get; set; }
        public Guid ManufacturerId { get; set; }

        public IEnumerable<Image> Images { get; set; }
    }
}