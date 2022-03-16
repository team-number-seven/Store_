using System;
using Shop.DAL.Interfaces;

namespace Shop.DAL.Entities
{
    public class Logo : IBaseEntity
    {
        public Guid Id { get; set; }
        public byte[] ImageData { get; set; }
        public string Format { get; set; }

        public Brand Brand { get; set; }
    }
}