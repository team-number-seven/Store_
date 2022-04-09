using MediatR;
using Store.BusinessLogic.Common;

namespace Store.BusinessLogic.Queries.AgeTypeQueries.GetAllAgeTypes
{
    public record GetAllAgeTypesQuery : IRequest<ResponseBase>;
}