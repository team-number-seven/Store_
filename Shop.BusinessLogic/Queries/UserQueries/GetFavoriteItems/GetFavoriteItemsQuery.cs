using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects.BagItem;

namespace Store.BusinessLogic.Queries.UserQueries.GetFavoriteItems
{
    public record GetFavoriteItemsQuery(string UserId,uint Count) : IRequest<ResponseBase>;
}
