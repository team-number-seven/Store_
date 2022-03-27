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
using Store.BusinessLogic.Common.Interfaces;
using Store.BusinessLogic.Common.Mappings;
using Store.BusinessLogic.Services;
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
            services.AddDbContext<StoreDbContext>(opt =>
                opt.UseNpgsql(Configuration.GetConnectionString("StoreConnection")));

            services
                .AddIdentityCore<User>()
                .AddRoles<IdentityRole<Guid>>()
                .AddEntityFrameworkStores<StoreDbContext>()
                .AddDefaultTokenProviders();


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
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = false,
                        ValidateIssuerSigningKey = false,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                    };
                });


            services.AddAutoMapper(config =>
            {
                config.AddProfile(new AssemblyMappingProfile(typeof(IMapWith<>).Assembly));
            });

            services.AddMediatR(typeof(CommandCreateUser).Assembly);
            services.AddValidators();
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            services.AddTransient<IJWTService, JWTService>();

            services.AddControllers();
            services.AddCors();


            return services;
        }
    }
}