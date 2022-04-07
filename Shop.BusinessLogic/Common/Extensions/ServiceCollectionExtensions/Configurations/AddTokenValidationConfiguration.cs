using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Store.BusinessLogic.Options;

namespace Store.BusinessLogic.Common.Extensions.ServiceCollectionExtensions.Configurations
{
    public static partial class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTokenValidationConfiguration(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<TokenValidationConfiguration>(configuration.GetSection("TokenValidationConfiguration"));
            return services;
        }
    }
}