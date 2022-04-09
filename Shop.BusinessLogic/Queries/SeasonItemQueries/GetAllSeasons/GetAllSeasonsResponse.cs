using System.Collections.Generic;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects.Season;

namespace Store.BusinessLogic.Queries.SeasonItemQueries.GetAllSeasons
{
    public record GetAllSeasonsResponse(IList<SeasonDto> Seasons) : ResponseBase;
}