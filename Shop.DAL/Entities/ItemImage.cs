using System;
using Store.DAL.Interfaces;

namespace Store.DAL.Entities
{
    public class ItemImage : IBaseEntity
    {
        public string Path { get; set; }

        public virtual ImageFormat ImageFormat { get; set; }
        public Guid ImageFormatId { get; set; }

        public virtual Item Item { get; set; }
        public Guid ItemId { get; set; }
        public Guid Id { get; set; }
    }
}