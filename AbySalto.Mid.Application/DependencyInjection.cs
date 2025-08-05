using AbySalto.Mid.Application.Favorite;
using AbySalto.Mid.Application.Product;
using AbySalto.Mid.Application.User;
using Microsoft.Extensions.DependencyInjection;
namespace AbySalto.Mid.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IFavoriteService, FavoriteService>();
            services.AddScoped<IUserRegistrationService, UserRegistrationService>();

            return services;
        }
    }
}
