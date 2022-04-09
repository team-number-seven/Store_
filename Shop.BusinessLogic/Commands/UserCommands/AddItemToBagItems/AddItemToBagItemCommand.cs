using MediatR;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects.BagItem;

namespace Store.BusinessLogic.Commands.UserCommands.AddItemToBagItems
{
    public record AddItemToBagItemCommand(AddBagItemDto BagItem) : IRequest<ResponseBase>;
}
