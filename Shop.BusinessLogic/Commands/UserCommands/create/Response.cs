using Store.BusinessLogic.Common;
using System;

namespace Store.BusinessLogic.Commands.UserCommands.create
{
    public static partial class CreateUser
    {
        public record Response(Guid Id) : ResponseBase;
    }
}
