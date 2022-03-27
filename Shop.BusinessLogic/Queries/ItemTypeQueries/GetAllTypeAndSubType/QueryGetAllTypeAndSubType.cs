using MediatR;
using Store.BusinessLogic.Common;

namespace Store.BusinessLogic.Queries.ItemTypeQueries.GetAllTypeAndSubType
{
    public record QueryGetAllTypeAndSubType : IRequest<ResponseBase>;
}