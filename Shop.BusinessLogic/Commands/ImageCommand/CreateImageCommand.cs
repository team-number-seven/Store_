using MediatR;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects;

namespace Store.BusinessLogic.Commands.ImageCommand
{
    public record CreateImageCommand(ImageCreateDto Images) : IRequest<ResponseBase>;
}