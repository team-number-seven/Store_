using System;
using MediatR;
using Store.BusinessLogic.Common;

namespace Store.BusinessLogic.Commands.UserCommands.DeleteUser
{
    public record CommandDeleteUser(Guid UserId) : IRequest<ResponseBase>;
}
