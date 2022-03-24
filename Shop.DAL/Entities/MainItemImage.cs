using System;
using Store.DAL.Interfaces;

namespace Store.DAL.Entities
{
    public class MainItemImage : IBaseEntity
    {
        public string Path { get; set; }

        public Guid ImageFormatId { get; set; }
        public ImageFormat ImageFormat { get; set; }

        public Item Item { get; set; }
        public Guid ItemId { get; set; }
        public Guid Id { get; set; }
    }
}