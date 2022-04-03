using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.JsonWebTokens.Tokens;

namespace Store.BusinessLogic.Queries.UserQueries.RefreshTokens
{
    public record ResponseRefreshTokens(AccessToken AccessToken, RefreshToken RefreshToken) : ResponseBase;
}
