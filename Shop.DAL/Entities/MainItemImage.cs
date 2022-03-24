using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.DAL.Interfaces;

namespace Store.DAL.Entities
{
    public class MainItemImage:IBaseEntity
    {
        public Guid Id { get; set; }
        public string Path { get; set; }

        public Guid ImageFormatId { get; set; }
        public ImageFormat ImageFormat { get; set; }

        public Item Item { get; set; }
        public Guid ItemId { get; set; }
    }
}
