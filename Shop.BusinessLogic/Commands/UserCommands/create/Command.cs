using MediatR;
using Store.BusinessLogic.Common;
using System;

namespace Store.BusinessLogic.Commands.UserCommands.create
{
    public static partial class CreateUser
    {
        public record Command(string UserName, string Email, string Password, Guid CountryId,
            string PhoneNumber) : IRequest<ResponseBase>;
    }
}
