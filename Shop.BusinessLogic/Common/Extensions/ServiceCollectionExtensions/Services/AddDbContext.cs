using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Store.DAL;
using Store.DAL.Interfaces;

namespace Store.BusinessLogic.Common.Extensions.ServiceCollectionExtensions.Services
{
    public static partial class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddDbContext<StoreDbContext>(
                    opt => opt.UseNpgsql(configuration.GetConnectionString("StoreConnection")))
                .AddScoped<IStoreDbContext>(
                    provider => provider.GetService<StoreDbContext>());
            return services;
        }
    }
}