using MediatR;
using Store.BusinessLogic.Common;

namespace Store.BusinessLogic.Queries.SeasonItemQueries.GetAllSeasons
{
    public record GetAllSeasonsQuery : IRequest<ResponseBase>;
}