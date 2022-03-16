using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.DAL.Interfaces;

namespace Shop.DAL.Entities
{
    public class FavoriteItem:IBaseEntity
    {
        public Guid Id { get; set; }

        public Item Item { get; set; }
        public Guid ItemId { get; set; }
    }
}
