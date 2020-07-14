using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace pool_api.Configuration
{
    public static class ConfigureAppExtensions
    {
        public static void ConfigureApp(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                // SwaggerConfig.Setup(app);
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            //app.UseRequestResponseLogging(); //Todo: We need to test UseRequestResponseLogging/RequestResponseLoggingMiddleware against UseSerilogRequestLogging


            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}