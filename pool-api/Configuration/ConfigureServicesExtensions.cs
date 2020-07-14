using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace pool_api.Configuration
{
    public static class ConfigureServicesExtensions
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            ConfigureDependencies(services);
            ConfigureFacades(services);
            ConfigureServices(services);
            ConfigureShared(services, configuration);
            ConfigureFrameworks(services);
        }


        private static void ConfigureDependencies(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200", "https://pool.klydevej7.dk");
                        builder.WithMethods("GET", "POST", "OPTIONS");
                        builder.AllowAnyHeader();
                        builder.AllowCredentials();
                    });
            });

            services.AddControllers();
        }

        private static void ConfigureFacades(IServiceCollection services)
        {
            // services.AddSingleton<ICustomerFacade, CustomerFacade>();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
        }

        private static void ConfigureShared(IServiceCollection services, IConfiguration configuration)
        {
        }

        private static void ConfigureFrameworks(IServiceCollection services)
        {
            // SwaggerConfig.Configure(services);
            services.AddCors();
            services.AddControllers();
        }
    }
}