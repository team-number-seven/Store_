using MediatR;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects;

namespace Store.BusinessLogic.Queries.UserQueries.LoginUser
{
    public record QueryLoginUser(UserLoginDTO User) : IRequest<ResponseBase>;
}
