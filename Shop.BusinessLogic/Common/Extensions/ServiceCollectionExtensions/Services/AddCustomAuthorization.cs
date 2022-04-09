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
                options.AddPolicy(PolicyRoles.Administrator,
                    builder => { builder.RequireClaim(ClaimTypes.Role, PolicyRoles.Administrator); });

                options.AddPolicy(PolicyRoles.User,
                    builder =>
                    {
                        builder.RequireAssertion(x =>
                            x.User.HasClaim(ClaimTypes.Role, PolicyRoles.User) ||
                            x.User.HasClaim(ClaimTypes.Role, PolicyRoles.Administrator));
                    });
                options.AddPolicy(PolicyRoles.Manager,
                    builder =>
                    {
                        builder.RequireAssertion(x =>
                            x.User.HasClaim(ClaimTypes.Role, PolicyRoles.Manager) ||
                            x.User.HasClaim(ClaimTypes.Role, PolicyRoles.Administrator));
                    });
            });
            return services;
        }
    }
}