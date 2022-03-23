using Store.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DAL.Entities
{
    public class SeasonItem:IBaseEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public IEnumerable<Item> Items { get; set; }

    }
}
