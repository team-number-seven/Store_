using MediatR;
using Store.BusinessLogic.Common;

namespace Store.BusinessLogic.Queries.UserQueries.GetBagItems
{
    public record GetBagItemsQuery(string UserId, uint Count) : IRequest<ResponseBase>;
}
