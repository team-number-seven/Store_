using MediatR;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects.Item;

namespace Store.BusinessLogic.Commands.ItemCommands.ItemCreate
{
    public record CreateItemCommand(CreateItemDto CreateItem) : IRequest<ResponseBase>;
}