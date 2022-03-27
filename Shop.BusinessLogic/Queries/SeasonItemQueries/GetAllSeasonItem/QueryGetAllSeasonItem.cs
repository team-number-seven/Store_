using MediatR;
using Store.BusinessLogic.Common;

namespace Store.BusinessLogic.Queries.SeasonItemQueries.GetAllSeasonItem
{
    public record QueryGetAllSeasonItem : IRequest<ResponseBase>;
}