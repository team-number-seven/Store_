using System;
using System.Collections.Generic;
using Store.DAL.Interfaces;

namespace Store.DAL.Entities
{
    public class ImageFormat : IBaseEntity
    {
        public string Format { get; set; }
        public virtual IEnumerable<ItemImage> Images { get; set; }
        public Guid Id { get; set; }
    }
}