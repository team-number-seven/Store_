using Microsoft.Extensions.DependencyInjection;
using Store.BusinessLogic.Common.Mappings;

namespace Store.BusinessLogic.Common.Extensions.ServiceCollectionExtensions.Services
{
    public static partial class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(config =>
            {
                config.AddProfile(new AssemblyMappingProfile(typeof(IMapWith<>).Assembly));
            });
            return services;
        }
    }
}