using System;
using Store.DAL.Interfaces;

namespace Store.DAL.Entities
{
    public class Logo : IBaseEntity
    {
        public string Path { get; set; }
        public string Format { get; set; }

        public Brand Brand { get; set; }
        public Guid Id { get; set; }
    }
}