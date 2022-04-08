using MediatR;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects.Item;

namespace Store.BusinessLogic.Queries.ItemQueries.GetByFilter
{
    public record QueryItemFilter(ItemFilterQueryDto Query) : IRequest<ResponseBase>;
}