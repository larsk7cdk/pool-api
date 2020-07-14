using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace pool_api.Configuration
{
    public static class SwaggerConfig
    {
        //public static void Configure(IServiceCollection services)
        //{
        //    services.AddSwaggerGen(opt => opt.SwaggerDoc("v1", new OpenApiInfo { Title = "BBoB Api", Version = "v1" }));
        //    // "Plus sign (+) precedes a nested class" - Det fjerner vi for at få en gyldig swagger.json
        //    // https://docs.microsoft.com/en-us/dotnet/api/system.type.assemblyqualifiedname?view=netcore-2.2#remarks
        //    services.ConfigureSwaggerGen(opt => opt.CustomSchemaIds(x => x.FullName?.Replace('+', '.')));

        //    services.AddSwaggerGen(opt =>
        //    {
        //        // Set the comments path for the Swagger JSON and UI.
        //        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        //        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        //        opt.IncludeXmlComments(xmlPath);
        //    });
        //}

        //public static void Setup(IApplicationBuilder app)
        //{
        //    app.UseSwagger();
        //    app.UseSwaggerUI(opt => opt.SwaggerEndpoint("/swagger/v1/swagger.json", "BBoB api V1"));
        //}
    }
}
