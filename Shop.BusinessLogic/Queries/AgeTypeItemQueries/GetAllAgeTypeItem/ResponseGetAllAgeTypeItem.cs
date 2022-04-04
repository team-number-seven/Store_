using System.Collections.Generic;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects;

namespace Store.BusinessLogic.Queries.AgeTypeItemQueries.GetAllAgeTypeItem
{
    public record ResponseGetAllAgeTypeItem(IList<AgeTypeItemDto> Types) : ResponseBase;
}