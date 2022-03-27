using MediatR;
using Store.BusinessLogic.Common;

namespace Store.BusinessLogic.Queries.AgeTypeItemQueries.GetAllAgeTypeItem
{
    public record QueryGetAllAgeTypeItem : IRequest<ResponseBase>;
}