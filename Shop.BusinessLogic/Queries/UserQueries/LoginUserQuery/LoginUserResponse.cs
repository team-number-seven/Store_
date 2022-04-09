using Store.BusinessLogic.Common;
using Store.BusinessLogic.Services.JsonWebTokens.Tokens;

namespace Store.BusinessLogic.Queries.UserQueries.LoginUserQuery
{
    public record LoginUserResponse(AccessToken AccessToken, RefreshTokenResponse RefreshToken) : ResponseBase;
}