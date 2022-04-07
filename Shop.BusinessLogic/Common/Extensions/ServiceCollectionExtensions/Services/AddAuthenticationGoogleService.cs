using Microsoft.Extensions.DependencyInjection;
using Store.BusinessLogic.Services.AuthenticationGoogle;
using Store.BusinessLogic.Services.AuthGoogle;

namespace Store.BusinessLogic.Common.Extensions.ServiceCollectionExtensions.Services
{
    public static partial class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAuthenticationGoogleService(this IServiceCollection services)
        {
            services.AddScoped(typeof(IAuthenticationGoogleService), typeof(AuthenticationGoogleService));
            return services;
        }
    }
}