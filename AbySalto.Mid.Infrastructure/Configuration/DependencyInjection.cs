using AbySalto.Mid.Domain.External;
using AbySalto.Mid.Infrastructure.External;
using AbySalto.Mid.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AbySalto.Mid.Infrastructure.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddServices();
            services.AddDatabase();

            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IProductApiFacade, ProductApiFacade>();
            services.AddSingleton(JsonOptionsProvider.DefaultOptions);

            return services;
        }

        private static IServiceCollection AddDatabase(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(EnvConfig.DB_CONNECTION_STRING));

            return services;
        }
    }
}
