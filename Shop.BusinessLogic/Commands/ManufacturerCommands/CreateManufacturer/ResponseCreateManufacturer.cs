using System;
using Store.BusinessLogic.Common;

namespace Store.BusinessLogic.Commands.ManufacturerCommands.CreateManufacturer
{
    public record ResponseCreateManufacturer(Guid Id) : ResponseBase;
}