using MediatR;
using Store.BusinessLogic.Common;

namespace Store.BusinessLogic.Queries.SizeTypeItemQueries.GetAllSizeTypeItems
{
    public record QueryGetAllSizesTypeItems : IRequest<ResponseBase>;
}