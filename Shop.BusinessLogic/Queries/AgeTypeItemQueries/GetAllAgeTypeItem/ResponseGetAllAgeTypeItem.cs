using System.Collections.Generic;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects.AgeType;

namespace Store.BusinessLogic.Queries.AgeTypeItemQueries.GetAllAgeTypeItem
{
    public record ResponseGetAllAgeTypeItem(IList<AgeTypeItemDto> Types) : ResponseBase;
}