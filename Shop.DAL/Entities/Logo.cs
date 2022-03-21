using System;
using Store.DAL.Interfaces;

namespace Store.DAL.Entities
{
    public class Logo : IBaseEntity
    {
        public Guid Id { get; set; }
        public string Path { get; set; }
        public string Format { get; set; }

        public Brand Brand { get; set; }
    }
}