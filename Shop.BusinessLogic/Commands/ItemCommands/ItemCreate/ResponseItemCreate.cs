using System;
using Store.BusinessLogic.Common;

namespace Store.BusinessLogic.Commands.ItemCommands.ItemCreate
{
    public record ResponseItemCreate(Guid Id) : ResponseBase;
}