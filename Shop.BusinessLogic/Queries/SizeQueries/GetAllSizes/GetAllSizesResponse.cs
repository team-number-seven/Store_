using System.Collections.Generic;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects.Size;

namespace Store.BusinessLogic.Queries.SizeQueries.GetAllSizes
{
    public record GetAllSizesResponse(IList<SizeDto> Sizes) : ResponseBase;
}