using System;
using MediatR;
using Store.BusinessLogic.Common;

namespace Store.BusinessLogic.Commands.UserCommands.DeleteUser
{
    public record DeleteUserCommand(Guid UserId) : IRequest<ResponseBase>;
}