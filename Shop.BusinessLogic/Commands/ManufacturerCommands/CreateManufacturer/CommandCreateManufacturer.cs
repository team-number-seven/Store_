using MediatR;
using Store.BusinessLogic.Common;

namespace Store.BusinessLogic.Commands.ManufacturerCommands.CreateManufacturer
{
    public record CommandCreateManufacturer(string Title) : IRequest<ResponseBase>;
}