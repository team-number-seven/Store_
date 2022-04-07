using System.Security.Claims;
using Microsoft.Extensions.DependencyInjection;

namespace Store.BusinessLogic.Common.Extensions.ServiceCollectionExtensions.Services
{
    public static partial class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomAuthorization(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Administrator",
                    builder => { builder.RequireClaim(ClaimTypes.Role, "Administrator"); });

                options.AddPolicy("User",
                    builder =>
                    {
                        builder.RequireAssertion(x =>
                            x.User.HasClaim(ClaimTypes.Role, "User") ||
                            x.User.HasClaim(ClaimTypes.Role, "Administrator"));
                    });
                options.AddPolicy("Manager",
                    builder =>
                    {
                        builder.RequireAssertion(x =>
                            x.User.HasClaim(ClaimTypes.Role, "Manager") ||
                            x.User.HasClaim(ClaimTypes.Role, "Administrator"));
                    });
            });
            return services;
        }
    }
}