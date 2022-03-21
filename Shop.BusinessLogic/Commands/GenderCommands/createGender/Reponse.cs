using System;
using Store.BusinessLogic.Common;

namespace Store.BusinessLogic.Commands.GenderCommands.createGender
{
    public static partial class CreateGender
    {
        public record Response(Guid Id) : ResponseBase;
    }
}
