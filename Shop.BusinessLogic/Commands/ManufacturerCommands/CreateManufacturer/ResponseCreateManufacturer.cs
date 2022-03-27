using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.BusinessLogic.Common;

namespace Store.BusinessLogic.Commands.ManufacturerCommands.CreateManufacturer
{
    public record ResponseCreateManufacturer(Guid Id) : ResponseBase;
}
