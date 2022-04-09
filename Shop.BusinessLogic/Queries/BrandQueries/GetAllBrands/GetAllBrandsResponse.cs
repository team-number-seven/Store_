﻿using System.Collections.Generic;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects.Brand;

namespace Store.BusinessLogic.Queries.BrandQueries.GetAllBrands
{
    public record GetAllBrandsResponse(IList<BrandDto> Brands) : ResponseBase;
}