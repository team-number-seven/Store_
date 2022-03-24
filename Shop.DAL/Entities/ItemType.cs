using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.DAL.Interfaces;

namespace Store.DAL.Entities
{
    public class ItemType:IBaseEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public IEnumerable<SubItemType> SubItemTypes { get; set; }
        public IEnumerable<CharacteristicItem> CharacteristicItems { get; set; }

        public IEnumerable<SizeItem> SizeItems { get; set; }

    }
}
