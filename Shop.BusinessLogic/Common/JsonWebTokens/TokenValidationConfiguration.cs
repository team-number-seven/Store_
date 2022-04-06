﻿using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Store.BusinessLogic.Common.JsonWebTokens
{
    public class TokenValidationConfiguration
    {
        private readonly IConfiguration _configuration;

        public TokenValidationConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public TokenValidationParameters AccessTokenParameters => new()
        {
            ValidateIssuer = true,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = _configuration["Jwt:Issuer"],
            ValidAudience = _configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]))
        };
    }
}