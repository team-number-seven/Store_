using System;
using Store.BusinessLogic.Common;

namespace Store.BusinessLogic.Commands.UserCommands.DeleteUser
{
    public record ResponseDeleteUser(Guid DeletedUser) : ResponseBase;
}