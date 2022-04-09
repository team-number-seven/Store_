using System.Collections.Generic;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects.Item;

namespace Store.BusinessLogic.Queries.ItemQueries.GetByItemsFilter
{
    public record GetItemsByFilterResponse(IList<ItemQueryResponseDto> Items) : ResponseBase;
}