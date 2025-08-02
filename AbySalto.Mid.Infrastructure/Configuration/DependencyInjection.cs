using AbySalto.Mid.Domain.External;
using AbySalto.Mid.Infrastructure.External;
using AbySalto.Mid.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using AbySalto.Mid.Infrastructure.Auth;
using AbySalto.Mid.Domain.Auth;
using AbySalto.Mid.Infrastructure.Persistence.Repository;
using AbySalto.Mid.Domain.User;

namespace AbySalto.Mid.Infrastructure.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddServices();
            services.AddDatabase();
            services.AddAuth();

            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IProductApiFacade, ProductApiFacade>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddSingleton(JsonOptionsProvider.DefaultOptions);

            return services;
        }

        private static IServiceCollection AddDatabase(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(EnvConfig.DB_CONNECTION_STRING));

            return services;
        }

        private static IServiceCollection AddAuth(this IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Authority = $"https://{EnvConfig.AUTH0_DOMAIN}/";
                    options.Audience = EnvConfig.AUTH0_AUDIENCE;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        NameClaimType = ClaimTypes.NameIdentifier
                    };
                });

            services.AddAuthorization();

            services.AddHttpContextAccessor();
            services.AddScoped<IIdentity, Identity>();

            return services;
        }
    }
}
