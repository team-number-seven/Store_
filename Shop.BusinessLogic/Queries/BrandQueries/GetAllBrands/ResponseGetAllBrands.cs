using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects;

namespace Store.BusinessLogic.Queries.BrandQueries.GetAllBrands
{
    public record ResponseGetAllBrands(IList<BrandDTO> Brands) : ResponseBase;
}
