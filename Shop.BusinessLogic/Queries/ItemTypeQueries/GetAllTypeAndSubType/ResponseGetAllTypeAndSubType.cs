using System.Collections.Generic;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects.ItemTypeAndSubType;

namespace Store.BusinessLogic.Queries.ItemTypeQueries.GetAllTypeAndSubType
{
    public record ResponseGetAllTypeAndSubType(IList<ItemTypeAndSubTypeDto> TypeAndSubItem) : ResponseBase;
}