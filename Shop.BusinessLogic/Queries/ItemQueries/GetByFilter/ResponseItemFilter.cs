using System.Collections.Generic;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects;

namespace Store.BusinessLogic.Queries.ItemQueries.GetByFilter
{
    public record ResponseItemFilter(IList<ItemQueryResponseDto> Items) : ResponseBase;
}