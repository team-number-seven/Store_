using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Store.BusinessLogic.Common;
using Store.DAL.Entities;

namespace Store.BusinessLogic.Queries.UserQueries
{
    public static class GetUserByName
    {
        public record Query(string userName) : IRequest<ResponseBase>;

        public class Handler : IRequestHandler<Query, ResponseBase>
        {
            private readonly IUserStore<User> _userStore;

            public Handler(IUserStore<User> userStore)
            {
                _userStore = userStore;
            }

            public async Task<ResponseBase> Handle(Query request, CancellationToken cancellationToken)
            {
                var user = await _userStore.FindByNameAsync(request.userName, cancellationToken);
                return user == null
                    ? new ResponseBase("User not found", HttpStatusCode.NotFound)
                    : new Response(user.Id, user.UserName, user.Email, user.PhoneNumber);
            }
        }

        public record Response(Guid Id, string UserName, string Email, string PhoneNumber) : ResponseBase;
    }
}