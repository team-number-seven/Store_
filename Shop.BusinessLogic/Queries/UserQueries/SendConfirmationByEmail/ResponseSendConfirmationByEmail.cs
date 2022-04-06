using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.BusinessLogic.Common;

namespace Store.BusinessLogic.Queries.UserQueries.SendConfirmationByEmail
{
    public record ResponseSendConfirmationByEmail(Guid UserId) : ResponseBase;
}
