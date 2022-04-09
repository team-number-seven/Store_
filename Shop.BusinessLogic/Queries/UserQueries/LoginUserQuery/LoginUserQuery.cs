using MediatR;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects.User;

namespace Store.BusinessLogic.Queries.UserQueries.LoginUserQuery
{
    public record LoginUserQuery(UserLoginDto User) : IRequest<ResponseBase>;
}