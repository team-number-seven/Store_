using MediatR;
using Store.BusinessLogic.Common;

namespace Store.BusinessLogic.Queries.UserQueries.RefreshTokens
{
    public record QueryRefreshTokens(string AccessToken, string RefreshToken) : IRequest<ResponseBase>;
}