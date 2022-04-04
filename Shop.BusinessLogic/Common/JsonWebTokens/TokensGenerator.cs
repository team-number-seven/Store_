using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Store.BusinessLogic.Common.JsonWebTokens.Interfaces;
using Store.BusinessLogic.Common.JsonWebTokens.Tokens;
using Store.DAL.Entities;
using Store.DAL.Interfaces;

namespace Store.BusinessLogic.Common.JsonWebTokens
{
    public class TokensGenerator : ITokensGenerator
    {
        private readonly TokenValidationParameters _accessTokenParameters;
        private readonly IStoreDbContext _context;
        private readonly ILogger<TokensGenerator> _logger;
        private readonly UserManager<User> _userManager;

        public TokensGenerator(UserManager<User> userManager, TokenValidationConfiguration tokenConfiguration,
            ILogger<TokensGenerator> logger, IStoreDbContext context)
        {
            _userManager = userManager;
            _logger = logger;
            _context = context;
            _accessTokenParameters = tokenConfiguration.AccessTokenParameters;
        }

        public async Task<AccessToken> GenerateAccessTokenAsync(User user, CancellationToken cancellationToken)
        {
            var credentials =
                new SigningCredentials(_accessTokenParameters.IssuerSigningKey, SecurityAlgorithms.HmacSha256);
            var userRoles = await _userManager.GetRolesAsync(user);
            var claims = new List<Claim>
            {
                new("Id", user.Id.ToString()),
                new(ClaimTypes.Country, user.Country.Name),
                new(ClaimTypes.Email, user.Email),
                new(ClaimTypes.Name, user.UserName)
            };
            claims.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));

            var token = new JwtSecurityToken(
                _accessTokenParameters.ValidIssuer,
                _accessTokenParameters.ValidAudience,
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);

            if (token.Payload.Exp is not null)
            {
                _logger.LogInformation(MHFL.Done("GenerateAccessTokenAsync", user.Id.ToString()));
                return new AccessToken(new JwtSecurityTokenHandler().WriteToken(token),
                    token.Payload.Exp.Value.ToString());
            }

            _logger.LogCritical("TokensGenerator.GenerateAccessTokenAsync() generate token.Payload.Exp == null");
            throw new ArgumentNullException("token.Payload.Exp can not be null");
        }

        public async Task<RefreshToken> GenerateRefreshToken(User user, CancellationToken cancellationToken)
        {
            var token = await _userManager.GenerateUserTokenAsync(user, "Default", "RefreshToken");
            var expires = ((DateTimeOffset) DateTime.Now.AddDays(60)).ToUnixTimeSeconds().ToString();
            return new RefreshToken(token, expires);
        }
    }
}