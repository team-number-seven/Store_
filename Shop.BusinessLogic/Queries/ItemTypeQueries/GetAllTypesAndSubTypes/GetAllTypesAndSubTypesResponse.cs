using System.Collections.Generic;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects.ItemTypeAndSubType;

namespace Store.BusinessLogic.Queries.ItemTypeQueries.GetAllTypesAndSubTypes
{
    public record GetAllTypesAndSubTypesResponse(IList<ItemTypeAndSubTypeDto> TypeAndSubItem) : ResponseBase;
}