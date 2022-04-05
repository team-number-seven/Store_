using System.Collections.Generic;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects;

namespace Store.BusinessLogic.Queries.SeasonItemQueries.GetAllSeasonItem
{
    public record ResponseGetAllSeasonItem(IList<SeasonItemDto> Seasons) : ResponseBase;
}