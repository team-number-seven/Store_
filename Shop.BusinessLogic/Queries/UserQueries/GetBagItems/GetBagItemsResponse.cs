using System.Collections.Generic;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects.BagItem;

namespace Store.BusinessLogic.Queries.UserQueries.GetBagItems
{
    public record GetBagItemsResponse(IList<GetBagItemDto> Items) : ResponseBase;
}
