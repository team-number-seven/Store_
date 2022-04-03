using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.JsonWebTokens.Interfaces;
using Store.DAL.Entities;
using Store.DAL.Interfaces;

namespace Store.BusinessLogic.Queries.UserQueries.LoginUser
{
    public class HandlerLoginUser : IRequestHandler<QueryLoginUser, ResponseBase>
    {
        private readonly ILogger<HandlerLoginUser> _logger;
        private readonly ITokensGenerator _tokensGenerator;
        private readonly IStoreDbContext _context;
        private readonly UserManager<User> _userManager;

        public HandlerLoginUser(UserManager<User> userManager, IStoreDbContext context,
            ILogger<HandlerLoginUser> logger, ITokensGenerator tokensGenerator)
        {
            _userManager = userManager;
            _context = context;
            _logger = logger;
            _tokensGenerator = tokensGenerator;
        }

        public async Task<ResponseBase> Handle(QueryLoginUser request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.User.Email);
            var accessToken = await _tokensGenerator.GenerateAccessTokenAsync(user);
            var refreshToken = await _tokensGenerator.GenerateRefreshToken(user);
            await _userManager.SetAuthenticationTokenAsync(user, "Default", "RefreshToken", refreshToken.Token);
            var token = await _context.Tokens.FirstOrDefaultAsync(t => t.UserId == user.Id,cancellationToken);
            token.Expire = refreshToken.Expires;
            _context.Tokens.Update(token);
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation($"{MHFL.Done("Handle", user.Id.ToString())}");
            return new ResponseLoginUser(accessToken, refreshToken);
        }
    }
}