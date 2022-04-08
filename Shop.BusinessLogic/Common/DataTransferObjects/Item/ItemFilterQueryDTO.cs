using System;
using System.Collections.Generic;

namespace Store.BusinessLogic.Common.DataTransferObjects.Item
{
    //TODO FIX FILTER(MB)
    public class ItemFilterQueryDto
    {
        public string MaxPrice { get; set; }
        public string MinPrice { get; set; }
        public List<Guid> BrandsId { get; set; }
        public List<Guid> ColorsId { get; set; }
        public List<Guid> SizesId { get; set; }
        public Guid AgeTypeId { get; set; }
        public List<Guid> SeasonsId { get; set; }
        public List<Guid> GendersId { get; set; }
        public List<Guid> ItemTypesId { get; set; }
        public List<Guid> SubItemTypesId { get; set; }
        public int GetCountItems { get; set; }
    }
}