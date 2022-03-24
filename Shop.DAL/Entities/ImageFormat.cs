using System;
using System.Collections.Generic;
using Store.DAL.Interfaces;

namespace Store.DAL.Entities
{
    public class ImageFormat : IBaseEntity
    {
        public string Format { get; set; }
        public IEnumerable<MainItemImage> MainItemImages { get; set; }
        public IEnumerable<SecondaryItemImage> SecondaryItemImage { get; set; }
        public IEnumerable<Logo> Logos { get; set; }
        public Guid Id { get; set; }
    }
}