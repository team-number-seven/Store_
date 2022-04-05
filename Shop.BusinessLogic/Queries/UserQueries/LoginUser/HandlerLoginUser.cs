using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.JsonWebTokens.Interfaces;
using Store.BusinessLogic.Common.JsonWebTokens.Tokens;
using Store.DAL.Entities;
using Store.DAL.Interfaces;

namespace Store.BusinessLogic.Queries.UserQueries.LoginUser
{
    public class HandlerLoginUser : IRequestHandler<QueryLoginUser, ResponseBase>
    {
        private readonly IStoreDbContext _context;
        private readonly ILogger<HandlerLoginUser> _logger;
        private readonly ITokensGenerator _tokensGenerator;
        private readonly CustomerSignInManager _sunInManager;
        private readonly UserManager<User> _userManager;

        public HandlerLoginUser(UserManager<User> userManager, IStoreDbContext context,
            ILogger<HandlerLoginUser> logger, ITokensGenerator tokensGenerator,CustomerSignInManager sunInManager)
        {
            _userManager = userManager;
            _context = context;
            _logger = logger;
            _tokensGenerator = tokensGenerator;
            _sunInManager = sunInManager;
        }

        public async Task<ResponseBase> Handle(QueryLoginUser request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.User.Email);
            var accessToken = await _tokensGenerator.GenerateAccessTokenAsync(user, cancellationToken);
            var refreshToken = await _tokensGenerator.GenerateRefreshToken(user, cancellationToken);

            await UpdateRefreshTokenAsync(user, refreshToken, cancellationToken);
            _logger.LogInformation($"{MHFL.Done("Handle", user.Id.ToString())}");
            return new ResponseLoginUser(accessToken, refreshToken);
        }

        private async Task UpdateRefreshTokenAsync(User user, RefreshToken newToken, CancellationToken cancellationToken)
        {
            var (token, expires) = newToken;
            await _userManager.SetAuthenticationTokenAsync(user, "Default", "RefreshToken", token);
            var currentToken = await _context.Tokens.FirstOrDefaultAsync(t => t.UserId == user.Id, cancellationToken);
            currentToken.Expire = expires;
            _context.Tokens.Update(currentToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}