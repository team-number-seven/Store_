using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Store.BusinessLogic.Common;

namespace Store.BusinessLogic.Commands.ManufacturerCommands.CreateManufacturer
{
    public record CommandCreateManufacturer(string Title) : IRequest<ResponseBase>;
}
