using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using pool_api.AppData;
using pool_api.DomainModels;
using pool_api.DomainServices;

namespace pool_api.Configuration
{
    public static class ConfigureServicesExtensions
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            ConfigureDbContext(services);
            ConfigureDependencies(services);
            ConfigureFacades(services);
            ConfigureServices(services);
            ConfigureShared(services, configuration);
            ConfigureFrameworks(services);
        }

        private static void ConfigureDbContext(IServiceCollection services)
        {
            services.AddDbContext<AppDataDbContext>();
        }

        private static void ConfigureDependencies(IServiceCollection services)
        {
            // Domain Services
            services.AddTransient<IMeasuringService, MeasuringService>();

            // Repositories
            services.AddTransient<IRepository<Measuring>, Repository<Measuring>>();
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