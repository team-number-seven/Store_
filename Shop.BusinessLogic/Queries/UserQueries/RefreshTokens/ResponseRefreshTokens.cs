using Store.BusinessLogic.Common;
using Store.BusinessLogic.Services.JsonWebTokens.Tokens;

namespace Store.BusinessLogic.Queries.UserQueries.RefreshTokens
{
    public record ResponseRefreshTokens(AccessToken AccessToken, RefreshTokenResponse RefreshToken) : ResponseBase;
}