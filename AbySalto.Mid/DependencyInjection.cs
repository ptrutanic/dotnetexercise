using AbySalto.Mid.WebApi.Filters;
using Microsoft.OpenApi.Models;

namespace AbySalto.Mid.WebApi
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddScoped<EnsureUserExistsFilter>();
            services.AddOpenApi();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AbySalto", Version = "v1" });
            });

            return services;
        }
    }
}
