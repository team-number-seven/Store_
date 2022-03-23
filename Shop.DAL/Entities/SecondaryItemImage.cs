using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DAL.Entities
{
    public class SecondaryItemImage:BaseImage
    {
        public Guid ItemId { get; set; }
        public Item Item { get; set; }
    }
}
