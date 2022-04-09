using System;
using Store.BusinessLogic.Common;

namespace Store.BusinessLogic.Commands.UserCommands.DeleteUser
{
    public record DeleteUserResponse(Guid DeletedUser) : ResponseBase;
}