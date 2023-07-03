using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace HRMS.Extensions;

public static class SwaggerExtensions
{
    public static void AddSwaggerGen(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "HRMS API",
                Version = "v1",
                Description = "An API to perform operations for HRMS services.\r\n For recurring jobs open <a href=\"/hangfire\">Hangfire</a>.",
            });

            options.CustomSchemaIds(type => type.ToString());

            options.AddSecurityDefinition("Api-Key", new OpenApiSecurityScheme
            {
                Name = "Api-Key",
                Description = "Please insert Api key.",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Api-Key"
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Api-Key"
                            },
                            Name = "Api-Key",
                            In = ParameterLocation.Header
                        },
                        new string[] { }
                    }
                });
        });
    }

    public static void UseSwaggerUI(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("../swagger/v1/swagger.json", "HRMS API");
            options.DocExpansion(DocExpansion.None);
        });
    }
}