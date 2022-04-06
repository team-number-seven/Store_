using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Store.BusinessLogic.Common;
using MailKit;
using Store.BusinessLogic.Common.Options;
using Store.BusinessLogic.Services.AuthGoogle;
using Store.BusinessLogic.Services.EmailService;

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
            services.AddServices(Configuration);
            services.Configure<EmailConfigure>(Configuration.GetSection("Email"));
            services.Configure<GoogleConfiguration>(Configuration.GetSection("Google"));
            services.Configure<MessageConfirmOrDeclineToEmail>(
                Configuration.GetSection("MessageConfirmOrDeclineToEmail"));
            services.AddScoped(typeof(IEmailService), typeof(EmailService));
            services.AddScoped(typeof(IAuthGoogleService), typeof(AuthGoogleService));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(opt =>
            {
                opt.AllowAnyOrigin();
                opt.AllowAnyHeader();
                opt.AllowAnyMethod();
            });

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}