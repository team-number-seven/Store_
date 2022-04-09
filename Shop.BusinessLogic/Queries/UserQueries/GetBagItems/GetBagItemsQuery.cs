using System;
using MediatR;
using Store.BusinessLogic.Common;

namespace Store.BusinessLogic.Queries.UserQueries.GetBagItems
{
    public record GetBagItemsQuery(uint Count, string UserId) : IRequest<ResponseBase>;
}
