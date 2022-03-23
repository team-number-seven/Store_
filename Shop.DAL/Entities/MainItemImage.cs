using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DAL.Entities
{
    public class MainItemImage : BaseImage
    {
        public Item Item { get; set; }
        public Guid ItemId { get; set; }
    }
}
