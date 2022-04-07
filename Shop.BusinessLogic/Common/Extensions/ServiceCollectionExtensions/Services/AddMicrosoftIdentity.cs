using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Store.BusinessLogic.Services;
using Store.DAL;
using Store.DAL.Entities;

namespace Store.BusinessLogic.Common.Extensions.ServiceCollectionExtensions.Services
{
    public static partial class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMicrosoftIdentity(this IServiceCollection services)
        {
            services
                .AddIdentityCore<User>()
                .AddRoles<Role>()
                .AddEntityFrameworkStores<StoreDbContext>()
                .AddSignInManager<CustomerSignInManager>()
                .AddDefaultTokenProviders();
            return services;
        }
    }
}