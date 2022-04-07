using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Services.JsonWebTokens.Interfaces;
using Store.BusinessLogic.Services.JsonWebTokens.Tokens;
using Store.DAL.Entities;
using Store.DAL.Interfaces;

namespace Store.BusinessLogic.Queries.UserQueries.LoginUser
{
    public class HandlerLoginUser : IRequestHandler<QueryLoginUser, ResponseBase>
    {
        private readonly IStoreDbContext _context;
        private readonly ILogger<HandlerLoginUser> _logger;
        private readonly ITokensGenerator _tokensGenerator;
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
            var accessToken = await _tokensGenerator.GenerateAccessTokenAsync(user, cancellationToken);
            var refreshToken = await _tokensGenerator.GenerateRefreshTokenAsync(user, cancellationToken);

            await UpdateRefreshTokenAsync(user, refreshToken, cancellationToken);
            _logger.LogInformation(LoggerMessages.DoneMessage(nameof(Handle), user.Id.ToString()));

            return new ResponseLoginUser(accessToken, refreshToken);
        }

        private async Task UpdateRefreshTokenAsync(User user, RefreshToken newToken,
            CancellationToken cancellationToken)
        {
            var (token, expires) = newToken;
            await _userManager.SetAuthenticationTokenAsync(user, _userManager.Options.Tokens.AuthenticatorTokenProvider,
                "RefreshToken", token);
            var currentToken = await _context.Tokens.FirstOrDefaultAsync(t => t.UserId == user.Id, cancellationToken);
            currentToken.Expire = expires;
            _context.Tokens.Update(currentToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}