using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BusinessLogic.Common.DataTransferObjects
{
    public class ItemFilterQueryDTO
    {
        public string Price { get; set; }
        public List<Guid> BrandsId { get; set; }
        public List<Guid> ColorsId { get; set; }
        public List<Guid> SizesId { get; set; }
        public Guid AgeTypeId { get; set; }
        public List<Guid> SeasonsId { get; set; }
        public List<Guid> GendersId { get; set; }
        public List<Guid> ItemTypesId { get; set; }
        public List<Guid> SubItemTypesId { get; set; }
    }
}
