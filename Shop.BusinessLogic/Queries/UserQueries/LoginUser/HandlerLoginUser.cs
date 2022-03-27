using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.Interfaces;
using Store.DAL.Entities;
using Store.DAL.Interfaces;

namespace Store.BusinessLogic.Queries.UserQueries.LoginUser
{
    public class HandlerLoginUser : IRequestHandler<QueryLoginUser, ResponseBase>
    {
        private readonly IJWTService _jwtService;
        private readonly ILogger<HandlerLoginUser> _logger;
        private readonly IStoreDbContext _storeContext;
        private readonly UserManager<User> _userManager;

        public HandlerLoginUser(UserManager<User> userManager, IStoreDbContext storeContext, IJWTService jwtService,
            ILogger<HandlerLoginUser> logger)
        {
            _userManager = userManager;
            _storeContext = storeContext;
            _storeContext = storeContext;
            _jwtService = jwtService;
            _logger = logger;
        }

        public async Task<ResponseBase> Handle(QueryLoginUser request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.User.Email);
            await _storeContext.Entry(user).Reference(c => c.Country).LoadAsync(cancellationToken);
            _logger.LogInformation($"{MHFL.Done("Handle", user.Id.ToString())}");
            return new ResponseLoginUser(_jwtService.GenerateJwtToken(user));
        }
    }
}