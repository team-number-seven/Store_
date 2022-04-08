using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.DAL.Interfaces;

namespace Store.DAL.Entities
{
    public class ItemCountSize:IBaseEntity
    {
        public Guid Id { get; set; }

        public uint Count { get; set; }

        public virtual SizeTypeItem SizeTypeItem { get; set; }
        public Guid SizeTypeItemId { get; set; }

        public virtual CharacteristicItem CharacteristicItem { get; set; }
        public Guid CharacteristicItemId { get; set; }
    }
}
