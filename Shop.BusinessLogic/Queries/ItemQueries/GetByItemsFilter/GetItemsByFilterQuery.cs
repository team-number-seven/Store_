using MediatR;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects.Item;

namespace Store.BusinessLogic.Queries.ItemQueries.GetByItemsFilter
{
    public record GetItemsByFilterQuery(ItemFilterQueryDto Query) : IRequest<ResponseBase>;
}