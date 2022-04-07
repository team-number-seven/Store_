using Microsoft.Extensions.DependencyInjection;
using Store.BusinessLogic.Services.JsonWebTokens;
using Store.BusinessLogic.Services.JsonWebTokens.Interfaces;

namespace Store.BusinessLogic.Common.Extensions.ServiceCollectionExtensions.Services
{
    public static partial class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTokenGenerator(this IServiceCollection services)
        {
            services.AddScoped(typeof(ITokensGenerator), typeof(TokensGenerator));
            return services;
        }
    }
}