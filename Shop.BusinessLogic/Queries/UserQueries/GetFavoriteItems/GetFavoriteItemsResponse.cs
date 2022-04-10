using System.Collections.Generic;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects.FavoriteItem;

namespace Store.BusinessLogic.Queries.UserQueries.GetFavoriteItems
{
    public record GetFavoriteItemsResponse(IList<GetFavoriteItemDto> Items) : ResponseBase;
}
