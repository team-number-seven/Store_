using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.DAL.Interfaces;

namespace Store.DAL.Entities
{
    public class BagItem:IBaseEntity
    {
        public Guid Id { get; set; }

        public uint Amount { get; set; }
        public virtual Size Size { get; set; }
        public Guid SizeId { get; set; }

        public virtual User User { get; set; }
        public Guid UserId { get; set; }

        public virtual Item Item { get; set; }
        public Guid ItemId { get; set; }
    }
}
