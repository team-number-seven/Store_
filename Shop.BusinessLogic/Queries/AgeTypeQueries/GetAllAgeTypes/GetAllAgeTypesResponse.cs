using System.Collections.Generic;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects.AgeType;

namespace Store.BusinessLogic.Queries.AgeTypeQueries.GetAllAgeTypes
{
    public record GetAllAgeTypesResponse(IList<AgeTypeDto> Types) : ResponseBase;
}