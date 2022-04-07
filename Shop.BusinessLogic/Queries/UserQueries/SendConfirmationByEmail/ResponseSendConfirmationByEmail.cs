using System;
using Store.BusinessLogic.Common;

namespace Store.BusinessLogic.Queries.UserQueries.SendConfirmationByEmail
{
    public record ResponseSendConfirmationByEmail(Guid UserId) : ResponseBase;
}