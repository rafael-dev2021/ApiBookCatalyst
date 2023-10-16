using APIBookCatalyst.Interfaces;
using APIBookCatalyst.Models;
using APIBookCatalyst.Repositories;

namespace APIBookCatalyst.Extensions
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services
          , IConfiguration configuration)
        {
            services.Configure<DbMongoSettings>(configuration.GetSection("APIBookCatalystDatabase"));
            services.AddSingleton<ICategoryRepository, CategoryRepository>();
            services.AddSingleton<IProductRepository, ProductRepository>();
            services.AddControllers()
            .AddJsonOptions(
                options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
            return services;
        }
    }
}
