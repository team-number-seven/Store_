using Store.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DAL.Entities
{
    public class ImageFormat : IBaseEntity
    {
        public Guid Id { get; set; }
        public string Format { get; set; }
        public IEnumerable<MainItemImage> MainItemImages { get; set; }
        public IEnumerable<SecondaryItemImage> SecondaryItemImage { get; set; }
        public IEnumerable<Logo> Logos { get; set; }
    }
}
