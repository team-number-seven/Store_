using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Store.BusinessLogic.Common;

namespace Store.BusinessLogic.Queries.UserQueries.SendConfirmationByEmail
{
    public record QuerySendConfirmationByEmail(Guid UserId, IUrlHelper UrlHelper) : IRequest<ResponseBase>;
}