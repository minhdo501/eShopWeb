using AuthenticationPlugin;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using Microsoft.eShopWeb.ApplicationCore.Services;
using Microsoft.eShopWeb.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;

namespace EShopApi.Extensions
{
    public static class ConfigureAdditionalServices
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            services.AddScoped(typeof(IAsyncRepository<>), typeof(EfRepository<>));
            services.AddTransient<IBrandService, BrandService>();
            services.AddTransient<ITypeService, TypeService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<AuthService>();

            return services;
        }
        
    }
}
