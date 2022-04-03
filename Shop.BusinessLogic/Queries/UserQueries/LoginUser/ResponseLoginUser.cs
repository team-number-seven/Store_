using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.JsonWebTokens.Tokens;

namespace Store.BusinessLogic.Queries.UserQueries.LoginUser
{
    public record ResponseLoginUser(AccessToken AccessToken,RefreshToken RefreshToken) : ResponseBase;
}