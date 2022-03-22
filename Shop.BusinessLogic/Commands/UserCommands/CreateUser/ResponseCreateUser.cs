using System;
using Store.BusinessLogic.Common;

namespace Store.BusinessLogic.Commands.UserCommands.CreateUser
{
    public record ResponseCreateUser(Guid Id) : ResponseBase;
}