using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Store.BusinessLogic.Common.Extensions.ServiceCollectionExtensions.Services
{
    public static partial class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomAuthentication(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = bool.Parse(configuration["TokenValidationConfiguration:ValidateIssuer"]),
                        ValidateAudience = bool.Parse(configuration["TokenValidationConfiguration:ValidateAudience"]),
                        ValidateLifetime = bool.Parse(configuration["TokenValidationConfiguration:ValidateLifetime"]),
                        ValidateIssuerSigningKey =
                            bool.Parse(configuration["TokenValidationConfiguration:ValidateIssuerSigningKey"]),
                        IssuerSigningKey =
                            new SymmetricSecurityKey(
                                Encoding.UTF8.GetBytes(configuration["TokenValidationConfiguration:Key"])),
                        ValidIssuer = configuration["TokenValidationConfiguration:ValidIssuer"],
                        ValidAudience = configuration["TokenValidationConfiguration:ValidAudience"]
                    };
                }).AddCookie("Identity.Application");
            return services;
        }
    }
}