using Store.BusinessLogic.Common;

namespace Store.BusinessLogic.Queries.UserQueries.LoginUser
{
    public record ResponseLoginUser(string Token) : ResponseBase;
}