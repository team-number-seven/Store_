using MediatR;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects.User;

namespace Store.BusinessLogic.Queries.UserQueries.LoginUser
{
    public record QueryLoginUser(UserLoginDto User) : IRequest<ResponseBase>;
}