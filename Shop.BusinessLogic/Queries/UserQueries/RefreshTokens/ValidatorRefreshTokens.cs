using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.Extensions;
using Store.BusinessLogic.Common.JsonWebTokens;
using Store.BusinessLogic.Validation;
using Store.DAL.Entities;
using Store.DAL.Interfaces;

namespace Store.BusinessLogic.Queries.UserQueries.RefreshTokens
{
    public class ValidatorRefreshTokens:IValidationHandler<QueryRefreshTokens>
    {
        private readonly TokenValidationConfiguration _tokenValidationConfiguration;
        private readonly UserManager<User> _userManager;
        private readonly IStoreDbContext _context;

        public ValidatorRefreshTokens(TokenValidationConfiguration tokenValidationConfiguration,UserManager<User> userManager,IStoreDbContext context)
        {
            _tokenValidationConfiguration = tokenValidationConfiguration;
            _userManager = userManager;
            _context = context;
        }
        public async Task<ValidationResult> Validate(QueryRefreshTokens request)
        {
            var accessTokenParameters = _tokenValidationConfiguration.AccessTokenParameters;
            var tokenHandler = new JwtSecurityTokenHandler();

            var resultAccessToken = await tokenHandler.ValidateTokenAsync(request.AccessToken, new TokenValidationParameters
            {
                ValidateIssuer = accessTokenParameters.ValidateIssuer,
                ValidateAudience = accessTokenParameters.ValidateAudience,
                ValidateLifetime = false,
                ValidateIssuerSigningKey = accessTokenParameters.ValidateIssuerSigningKey,
                ValidIssuer = accessTokenParameters.ValidIssuer,
                ValidAudience = accessTokenParameters.ValidAudience,
                IssuerSigningKey = accessTokenParameters.IssuerSigningKey
            });
            if (!resultAccessToken.IsValid)
                return ValidationResult.Fail("Invalid token");

            var jwtToken = tokenHandler.ReadJwtToken(request.AccessToken);
            var id = jwtToken.Claims.FirstOrDefault(c => c.Type == "Id");
            var user = await _userManager.FindByIdAsync(id!.Value);
            var resultRefreshToken =
                await _userManager.VerifyUserRefreshTokenAsync(_context, user, request.RefreshToken, "Default");
            if(resultRefreshToken is false)
                return ValidationResult.Fail("Invalid token");
            return ValidationResult.Success;
        }
    }
}
