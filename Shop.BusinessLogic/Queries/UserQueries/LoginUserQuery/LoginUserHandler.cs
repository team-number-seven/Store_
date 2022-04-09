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

namespace Store.BusinessLogic.Queries.UserQueries.LoginUserQuery
{
    public class LoginUserHandler : IRequestHandler<LoginUserQuery, ResponseBase>
    {
        private readonly IStoreDbContext _context;
        private readonly ILogger<LoginUserHandler> _logger;
        private readonly ITokensGenerator _tokensGenerator;
        private readonly UserManager<User> _userManager;

        public LoginUserHandler(UserManager<User> userManager, IStoreDbContext context,
            ILogger<LoginUserHandler> logger, ITokensGenerator tokensGenerator)
        {
            _userManager = userManager;
            _context = context;
            _logger = logger;
            _tokensGenerator = tokensGenerator;
        }

        public async Task<ResponseBase> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.User.Email);
            var accessToken = await _tokensGenerator.GenerateAccessTokenAsync(user, cancellationToken);
            var refreshToken = await _tokensGenerator.GenerateRefreshTokenAsync(user, cancellationToken);

            await UpdateRefreshTokenAsync(user, refreshToken, cancellationToken);
            _logger.LogInformation(LoggerMessages.DoneMessage(nameof(Handle), user.Id.ToString()));

            return new LoginUserResponse(accessToken,
                new RefreshTokenResponse(refreshToken.Token, refreshToken.Expires));
        }

        private async Task UpdateRefreshTokenAsync(User user, RefreshToken newToken,
            CancellationToken cancellationToken)
        {
            var (token, expires, provider, purpose) = newToken;
            await _userManager.SetAuthenticationTokenAsync(user, provider, purpose, token);
            var currentToken =
                await _context.UserTokens.FirstOrDefaultAsync(t => t.UserId == user.Id, cancellationToken);
            currentToken.Expire = expires;
            _context.UserTokens.Update(currentToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}