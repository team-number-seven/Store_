using Microsoft.Extensions.DependencyInjection;
using Store.BusinessLogic.Services.Email;
using Store.BusinessLogic.Services.EmailService;

namespace Store.BusinessLogic.Common.Extensions.ServiceCollectionExtensions.Services
{
    public static partial class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEmailService(this IServiceCollection services)
        {
            services.AddScoped(typeof(IEmailService), typeof(EmailService));
            return services;
        }
    }
}