using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Store.BusinessLogic.Options;

namespace Store.BusinessLogic.Common.Extensions.ServiceCollectionExtensions.Configurations
{
    public static partial class ServiceCollectionExtensions
    {
        public static IServiceCollection AddConfirmAndDeclineUrlConfiguration(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<ConfirmAndDeclineUrlConfiguration>(
                configuration.GetSection("ConfirmAndDeclineUrl"));
            return services;
        }
    }
}