using MediatR;
using Store.BusinessLogic.Common;

namespace Store.BusinessLogic.Queries.SizeQueries.GetAllSizes
{
    public record GetAllSizesQuery : IRequest<ResponseBase>;
}