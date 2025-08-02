using AbySalto.Mid.Application.Services;
using AbySalto.Mid.Application.User;
using Microsoft.Extensions.DependencyInjection;
namespace AbySalto.Mid.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ProductService>();
            services.AddScoped<IUserRegistrationService, UserRegistrationService>();

            return services;
        }
    }
}
