using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Store.BusinessLogic.Options;

namespace Store.BusinessLogic.Common.Extensions.ServiceCollectionExtensions.Configurations
{
    public static partial class ServiceCollectionExtensions
    {
        public static IServiceCollection AddGoogleAuthenticationConfiguration(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<GoogleAuthenticationConfiguration>(configuration.GetSection("Google"));
            return services;
        }
    }
}