using System.Collections.Generic;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects;

namespace Store.BusinessLogic.Queries.SizeTypeItemQueries.GetAllSizeTypeItems
{
    public record ResponseGetAllSizesTypeItems(IList<SizeTypeItemDto> Sizes) : ResponseBase;
}