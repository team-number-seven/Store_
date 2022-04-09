using MediatR;
using Store.BusinessLogic.Common;

namespace Store.BusinessLogic.Queries.ItemTypeQueries.GetAllTypesAndSubTypes
{
    public record GetAllTypesAndSubTypesQuery : IRequest<ResponseBase>;
}