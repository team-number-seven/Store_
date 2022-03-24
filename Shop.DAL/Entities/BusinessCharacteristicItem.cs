using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.DAL.Interfaces;

namespace Store.DAL.Entities
{
    public class BusinessCharacteristicItem:IBaseEntity
    {
        public Guid Id { get; set; }
        public string ArticleNumber { get; set; }

        public Country Country { get; set; }
        public Guid CountryId { get; set; }

        public Manufacturer Manufacturer { get; set; }
        public Guid ManufacturerId { get; set; }

        public Item Item { get; set; }

    }
}
