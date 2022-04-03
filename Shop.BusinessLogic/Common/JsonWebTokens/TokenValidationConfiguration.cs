using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Store.BusinessLogic.Common.JsonWebTokens.Interfaces;

namespace Store.BusinessLogic.Common.JsonWebTokens
{
    public class TokenValidationConfiguration
    {
        private readonly IConfiguration _configuration;

        public TokenValidationConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public TokenValidationParameters AccessTokenParameters => new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = false,
            ValidateIssuerSigningKey = false,
            ValidIssuer = _configuration["Jwt:Issuer"],
            ValidAudience = _configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]))
        };
    }
}
