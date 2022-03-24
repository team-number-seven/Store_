using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.DAL.Interfaces;

namespace Store.DAL.Entities
{
    public class WarehouseItem:IBaseEntity
    {
        public Guid Id { get; set; }

        public IEnumerable<Item> Items { get; set; }
    }
}
