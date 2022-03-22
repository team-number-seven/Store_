using System;
using MediatR;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects;

namespace Store.BusinessLogic.Commands.UserCommands.CreateUser
{
    public record CommandCreateUser(UserRegistrationDTO User) : IRequest<ResponseBase>;
}