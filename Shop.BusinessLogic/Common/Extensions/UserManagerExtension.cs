using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Store.BusinessLogic.Common.JsonWebTokens.Tokens;
using Store.DAL.Entities;
using Store.DAL.Interfaces;

namespace Store.BusinessLogic.Common.Extensions
{
    public static class UserManagerExtension
    {
        public static async Task<bool> VerifyUserRefreshTokenAsync(this UserManager<User> userManager,IStoreDbContext context,User user,string refreshToken,string provider)
        {
            var userRefreshToken =
                await context.Tokens.FirstOrDefaultAsync(t => t.UserId == user.Id && t.LoginProvider == provider);

            var token = long.Parse(userRefreshToken.Expire);
            var now = DateTimeOffset.Now.ToUnixTimeSeconds();
            if (userRefreshToken.Value != refreshToken ||
                long.Parse(userRefreshToken.Expire) < DateTimeOffset.Now.ToUnixTimeSeconds())
            {
                return false;
            }
            return true;
        }

        public static async Task<bool> SetUserRefreshTokenAsync(this UserManager<User> userManager, IStoreDbContext context,
            User user, RefreshToken refreshToken, string provider)
        {
            var userRefreshToken = await context.Tokens.FirstOrDefaultAsync(t => t.UserId == user.Id && t.LoginProvider == provider);
            if (userRefreshToken is null)
                return false;
            userRefreshToken.Expire = refreshToken.Expires;
            userRefreshToken.Value = refreshToken.Token;
            context.Tokens.Update(userRefreshToken);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
