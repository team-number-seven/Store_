using System;
using System.Security.Claims;
using System.Text;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Store.BusinessLogic.Behaviours;
using Store.BusinessLogic.Commands.UserCommands.CreateUser;
using Store.BusinessLogic.Common.JsonWebTokens;
using Store.BusinessLogic.Common.JsonWebTokens.Interfaces;
using Store.BusinessLogic.Common.Mappings;
using Store.BusinessLogic.Validation;
using Store.DAL;
using Store.DAL.Entities;
using Store.DAL.Interfaces;

namespace Store.BusinessLogic.Common
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration Configuration)
        {
            var tokenValidationConfig = new TokenValidationConfiguration(Configuration);
            services.AddDbContext<StoreDbContext>(opt =>
                opt.UseNpgsql(Configuration.GetConnectionString("StoreConnection")));

            services
                .AddIdentityCore<User>()
                .AddRoles<Role>()
                .AddEntityFrameworkStores<StoreDbContext>()
                .AddDefaultTokenProviders();


            services.AddTransient(typeof(ITokensGenerator), (typeof(TokensGenerator)));



            services.Configure<IdentityOptions>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = false;
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
            });


            services.AddScoped<IStoreDbContext>(provider =>
                provider.GetService<StoreDbContext>());

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Administrator",
                    builder => { builder.RequireClaim(ClaimTypes.Role, "Administrator"); });

                options.AddPolicy("User",
                    builder =>
                    {
                        builder.RequireAssertion(x =>
                            x.User.HasClaim(ClaimTypes.Role, "User") ||
                            x.User.HasClaim(ClaimTypes.Role, "Administrator"));
                    });
                options.AddPolicy("Manager",
                    builder =>
                    {
                        builder.RequireAssertion(x =>
                            x.User.HasClaim(ClaimTypes.Role, "Manager") ||
                            x.User.HasClaim(ClaimTypes.Role, "Administrator"));
                    });
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = tokenValidationConfig.AccessTokenParameters;
                });


            services.AddAutoMapper(config =>
            {
                config.AddProfile(new AssemblyMappingProfile(typeof(IMapWith<>).Assembly));
            });

            services.AddMediatR(typeof(CommandCreateUser).Assembly);
            services.AddValidators();
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            services.AddSingleton<TokenValidationConfiguration>();
            services.AddControllers();
            services.AddCors();


            return services;
        }
    }
}