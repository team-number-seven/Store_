using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.JsonWebTokens.Tokens;

namespace Store.BusinessLogic.Queries.UserQueries.RefreshTokens
{
    public record ResponseRefreshTokens(AccessToken AccessToken, RefreshToken RefreshToken) : ResponseBase;
}