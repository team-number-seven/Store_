using System;
using Store.DAL.Interfaces;

namespace Store.DAL.Entities
{
    public class NumberOfSize : IBaseEntity
    {
        public uint Count { get; set; }

        public virtual Size Size { get; set; }
        public Guid SizeId { get; set; }

        public virtual Characteristic Characteristic { get; set; }
        public Guid CharacteristicItemId { get; set; }
        public Guid Id { get; set; }
    }
}