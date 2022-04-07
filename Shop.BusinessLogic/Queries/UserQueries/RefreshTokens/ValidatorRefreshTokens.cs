using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Store.BusinessLogic.Common.Extensions;
using Store.BusinessLogic.Options;
using Store.BusinessLogic.Validation;
using Store.DAL.Entities;
using Store.DAL.Interfaces;

namespace Store.BusinessLogic.Queries.UserQueries.RefreshTokens
{
    public class ValidatorRefreshTokens : IValidationHandler<QueryRefreshTokens>
    {
        private readonly IStoreDbContext _context;
        private readonly TokenValidationConfiguration _tokenValidationConfiguration;
        private readonly UserManager<User> _userManager;

        public ValidatorRefreshTokens(IOptions<TokenValidationConfiguration> tokenValidationConfiguration,
            UserManager<User> userManager, IStoreDbContext context)
        {
            _tokenValidationConfiguration = tokenValidationConfiguration.Value;
            _userManager = userManager;
            _context = context;
        }

        public async Task<ValidationResult> Validate(QueryRefreshTokens request, CancellationToken cancellationToken)
        {
            var accessTokenParameters = _tokenValidationConfiguration.CreateTokenValidationParameters();
            var tokenHandler = new JwtSecurityTokenHandler();

            var (accessToken, refreshToken) = request;
            var resultAccessToken = await tokenHandler.ValidateTokenAsync(accessToken, new TokenValidationParameters
            {
                ValidateIssuer = accessTokenParameters.ValidateIssuer,
                ValidateAudience = accessTokenParameters.ValidateAudience,
                ValidateLifetime = false,
                ValidateIssuerSigningKey = accessTokenParameters.ValidateIssuerSigningKey,
                ValidIssuer = accessTokenParameters.ValidIssuer,
                ValidAudience = accessTokenParameters.ValidAudience,
                IssuerSigningKey = accessTokenParameters.IssuerSigningKey
            });
            if (!resultAccessToken.IsValid) return ValidationResult.Fail("Invalid token");

            var jwtToken = tokenHandler.ReadJwtToken(accessToken);
            var id = jwtToken.Claims.FirstOrDefault(c => c.Type == "Id");
            var user = await _userManager.FindByIdAsync(id!.Value);
            var resultRefreshToken =
                await _userManager.VerifyUserRefreshTokenAsync(_context, user, refreshToken, "Default");

            return resultRefreshToken is false
                ? ValidationResult.Fail("Invalid token")
                : ValidationResult.Success;
        }
    }
}