using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Store.BusinessLogic.Common.Extensions.ServiceCollectionExtensions.Configurations;

namespace Store.BusinessLogic.DependencyInjection
{
    public static partial class DependencyInjection
    {
        public static IServiceCollection AddConfigurations(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddEmailConfiguration(configuration);

            services.AddGoogleAuthenticationConfiguration(configuration);

            services.AddConfirmAndDeclineUrlConfiguration(configuration);

            services.AddIdentityOptionsConfiguration();

            services.AddTokenValidationConfiguration(configuration);
            return services;
        }
    }
}