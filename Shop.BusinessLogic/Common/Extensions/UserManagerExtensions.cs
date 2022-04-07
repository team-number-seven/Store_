using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Store.BusinessLogic.Services.JsonWebTokens.Tokens;
using Store.DAL.Entities;
using Store.DAL.Interfaces;

namespace Store.BusinessLogic.Common.Extensions
{
    public static class UserManagerExtensions
    {
        public static async Task<bool> VerifyUserRefreshTokenAsync(
            this UserManager<User> userManager,
            IStoreDbContext context,
            User user,
            string refreshToken,
            string provider
        )
        {
            var userRefreshToken =
                await context.Tokens.FirstOrDefaultAsync(t => t.UserId == user.Id && t.LoginProvider == provider);
            var token = long.Parse(userRefreshToken.Expire);
            var now = DateTimeOffset.Now.ToUnixTimeSeconds();

            return userRefreshToken.Value == refreshToken &&
                   long.Parse(userRefreshToken.Expire) >= DateTimeOffset.Now.ToUnixTimeSeconds();
        }

        public static async Task<bool> SetUserRefreshTokenAsync(this UserManager<User> userManager,
            IStoreDbContext context,
            User user,
            RefreshToken refreshToken,
            string provider
        )
        {
            var userRefreshToken =
                await context.Tokens.FirstOrDefaultAsync(t => t.UserId == user.Id && t.LoginProvider == provider);
            if (userRefreshToken is null)
                return false;

            var (token, expires) = refreshToken;
            userRefreshToken.Expire = expires;
            userRefreshToken.Value = token;
            context.Tokens.Update(userRefreshToken);
            await context.SaveChangesAsync();

            return true;
        }

        public static async Task<string> GenerateEmailConfirmationTokenAsync(
            this UserManager<User> userManager,
            string userId
        )
        {
            var user = await userManager.FindByIdAsync(userId);
            if (user is null) return null;
            var token = await userManager.GenerateEmailConfirmationTokenAsync(user);

            return token;
        }
    }
}