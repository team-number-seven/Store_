using MediatR;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects;

namespace Store.BusinessLogic.Queries.ItemQueries.GetByFilter
{
    public record QueryItemFilter(ItemFilterQueryDto Query) : IRequest<ResponseBase>;
}