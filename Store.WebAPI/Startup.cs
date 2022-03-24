using System;
using System.Security.Claims;
using System.Text;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Store.BusinessLogic.Behaviours;
using Store.BusinessLogic.Commands.UserCommands.CreateUser;
using Store.BusinessLogic.Common.Interfaces;
using Store.BusinessLogic.Common.Mappings;
using Store.BusinessLogic.Services;
using Store.BusinessLogic.Validation;
using Store.DAL;
using Store.DAL.Entities;
using Store.DAL.Interfaces;

namespace Store.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<StoreDbContext>(opt =>
                opt.UseNpgsql(Configuration.GetConnectionString("StoreConnection")));

            services.AddScoped<IStoreDbContext>(provider =>
                provider.GetService<StoreDbContext>());

            services.AddAutoMapper(config =>
            {
                config.AddProfile(new AssemblyMappingProfile(typeof(IMapWith<>).Assembly));
            });

            services.AddValidators();
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            services.AddTransient<IJWTService, JWTService>();


            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = false,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Jwt:MainPath"],
                        ValidAudience = Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                    };
                });

            services
                .AddIdentity<User, IdentityRole<Guid>>()
                .AddEntityFrameworkStores<StoreDbContext>();

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

            services.AddMediatR(typeof(CommandCreateUser).Assembly);

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Store.WebAPI", Version = "v1"});
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Store.WebAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}