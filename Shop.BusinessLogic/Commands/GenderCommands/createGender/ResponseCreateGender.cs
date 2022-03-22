using System;
using Store.BusinessLogic.Common;

namespace Store.BusinessLogic.Commands.GenderCommands.CreateGender
{
    public record ResponseCreateGender(Guid Id) : ResponseBase;
}