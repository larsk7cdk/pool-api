using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using pool_api.Extensions;

namespace pool_api.Configuration
{
    public static class ConfigureAppExtensions
    {
        public static void ConfigureApp(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                // SwaggerConfig.Setup(app);
                app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

            app.UseRouting();

            UseExceptionHandler(app);

            UseCors(app);

            app.UseRequestResponseLogging(); //Todo: We need to test UseRequestResponseLogging/RequestResponseLoggingMiddleware against UseSerilogRequestLogging


            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

        private static void UseExceptionHandler(IApplicationBuilder app)
        {
            app.UseExceptionHandler(
                builder =>
                {
                    builder.Run(
                        async context =>
                        {
                            context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                            context.Response.Headers.Add("Access-Control-Allow-Origin", "*");

                            var error = context.Features.Get<IExceptionHandlerFeature>();
                            if (error != null)
                            {
                                context.Response.AddApplicationError(error.Error.Message);
                                await context.Response.WriteAsync(error.Error.Message).ConfigureAwait(false);
                            }
                        });
                });
        }


        private static void UseCors(IApplicationBuilder app)
        {
            app.UseCors(builder =>
            {
                builder.WithOrigins("http://localhost:4200", "https://pool.klydevej7.dk");
                builder.WithMethods("GET", "POST", "OPTIONS");
                builder.AllowAnyHeader();
                builder.AllowCredentials();
            });
        }
    }
}