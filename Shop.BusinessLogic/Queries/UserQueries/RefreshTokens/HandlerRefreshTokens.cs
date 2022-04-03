﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.Extensions;
using Store.BusinessLogic.Common.JsonWebTokens;
using Store.BusinessLogic.Common.JsonWebTokens.Interfaces;
using Store.DAL.Entities;
using Store.DAL.Interfaces;

namespace Store.BusinessLogic.Queries.UserQueries.RefreshTokens
{
    public class HandlerRefreshTokens : IRequestHandler<QueryRefreshTokens, ResponseBase>
    {
        private readonly ITokensGenerator _tokensGenerator;
        private readonly ILogger<HandlerRefreshTokens> _logger;
        private readonly UserManager<User> _userManager;
        private readonly TokenValidationConfiguration _tokenValidationConfiguration;
        private readonly IStoreDbContext _context;

        public HandlerRefreshTokens(ITokensGenerator tokensGenerator, ILogger<HandlerRefreshTokens> logger,
            UserManager<User> userManager,TokenValidationConfiguration tokenValidationConfiguration,IStoreDbContext context)
        {
            _tokensGenerator = tokensGenerator;
            _logger = logger;
            _userManager = userManager;
            _tokenValidationConfiguration = tokenValidationConfiguration;
            _context = context;
        }

        public async Task<ResponseBase> Handle(QueryRefreshTokens request, CancellationToken cancellationToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(request.AccessToken);
            var id = jwtToken.Claims.FirstOrDefault(c=>c.Type == "Id");
            var user = await _userManager.FindByIdAsync(id!.Value);

            var accessToken = await _tokensGenerator.GenerateAccessTokenAsync(user);
            var refreshToken = await _tokensGenerator.GenerateRefreshToken(user);
            var result = await _userManager.SetUserRefreshTokenAsync(_context, user, refreshToken, "Default");
            if (result is false)
            {
                _logger.LogInformation(MHFL.NameObjectIsNullOrEmptyMessage("provider or user"));
                return new ResponseBase("Invalid user or provider", HttpStatusCode.BadRequest);
            }
            _logger.LogInformation(MHFL.Done("Handle",id.ToString()));
            return new ResponseRefreshTokens(accessToken, refreshToken);
        }
    }
}