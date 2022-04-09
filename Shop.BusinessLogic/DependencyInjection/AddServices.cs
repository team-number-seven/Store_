using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Store.BusinessLogic.Commands.UserCommands.CreateUser;
using Store.BusinessLogic.Common.Extensions.ServiceCollectionExtensions.Services;
using Store.BusinessLogic.Validation;

namespace Store.BusinessLogic.DependencyInjection
{
    public static partial class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext(configuration);

            services.AddMicrosoftIdentity();

            services.AddTokenGenerator();

            services.AddCustomAutoMapper();

            services.AddEmailService();

            services.AddAuthenticationGoogleService();

            services.AddCustomAuthentication(configuration);

            services.AddCustomAuthorization();

            services.AddMediatR(typeof(CreateUserCommand).Assembly);

            services.AddValidators();

            services.AddValidationBehaviour();

            services.AddValidationService();

            services.AddControllers();

            services.AddCors();

            return services;
        }
    }
}