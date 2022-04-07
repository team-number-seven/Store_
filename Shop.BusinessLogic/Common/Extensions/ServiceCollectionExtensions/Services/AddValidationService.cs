using Microsoft.Extensions.DependencyInjection;
using Store.BusinessLogic.Services.Validation;

namespace Store.BusinessLogic.Common.Extensions.ServiceCollectionExtensions.Services
{
    public static partial class ServiceCollectionExtensions
    {
        public static IServiceCollection AddValidationService(this IServiceCollection services)
        {
            services.AddScoped(typeof(IValidationService), typeof(ValidationService));
            return services;
        }
    }
}