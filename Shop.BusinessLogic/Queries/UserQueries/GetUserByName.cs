using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Store.DAL.Entities;

namespace Store.BusinessLogic.Queries.UserQueries
{
    public static class GetUserByName
    {
        public record Query(string userName) : IRequest<Response>;

        public class Handler:IRequestHandler<Query,Response>
        {
            private readonly IUserStore<User> _userStore;

            public Handler(IUserStore<User> userStore)
            {
                _userStore = userStore;
            }

            public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
            {
                var user = await _userStore.FindByNameAsync(request.userName,cancellationToken);
                return user == null ? null : new Response(user.Id, user.UserName, user.Email, user.PhoneNumber);
            }
        }

        public record Response(Guid Id, string UserName, string Email, string PhoneNumber);
    }
}
