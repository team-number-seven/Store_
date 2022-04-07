using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Store.DAL.Entities;

namespace Store.BusinessLogic.Common.Extensions
{
    public static class UserManagerExtensions
    {
        public static async Task<string> GenerateEmailConfirmationTokenAsync(
            this UserManager<User> userManager,
            string userId
            )
        {
            var user = await userManager.FindByIdAsync(userId);
            if (user is null) return null;
            var token =  await userManager.GenerateEmailConfirmationTokenAsync(user);

            return token;
        }
    }
}
