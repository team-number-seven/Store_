using System.Collections.Generic;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects;

namespace Store.BusinessLogic.Queries.BrandQueries.GetAllBrands
{
    public record ResponseGetAllBrands(IList<BrandDto> Brands) : ResponseBase;
}