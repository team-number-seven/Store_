using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Store.BusinessLogic.Common.Interfaces;
using Store.DAL.Entities;

namespace Store.BusinessLogic.Services
{
    public class JWTService:IJWTService
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;
        private readonly SymmetricSecurityKey _securityKey;

        public JWTService(IConfiguration configuration,UserManager<User> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
            _securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        }
        public string GenerateJwtToken(User user)
        {
            var credentials = new SigningCredentials(_securityKey, SecurityAlgorithms.HmacSha256);
            var userRoles = _userManager.GetRolesAsync(user);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Country, user.Country.Name),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Name,user.UserName),
            };
            foreach (var role in userRoles.Result)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));    
            }

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }

}
