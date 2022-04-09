using System;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects.BagItem;

namespace Store.BusinessLogic.Commands.UserCommands.AddItemToBagItems
{
    public record AddItemToBagItemResponse(Guid Id) : ResponseBase;
}
