using HRMS.Database.Mappings;
using HRMS.Mappings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace HRMS.Extensions;

public static class ServiceExtensions
{
    public static void AddAuthentication(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                         .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                         {
                             options.Authority = configuration.GetValue<string>("IdentityServerUrl")!;

                             var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetValue<string>("IdentityServerJWTSecret")!));

                             options.TokenValidationParameters.ValidateAudience = false;
                             options.TokenValidationParameters.ValidateIssuer = false;
                             options.TokenValidationParameters.ValidateLifetime = true;
                             options.TokenValidationParameters.ValidateIssuerSigningKey = true;
                             options.TokenValidationParameters.IssuerSigningKey = secretKey;
                         });
    }

    public static void AddAutoMapper(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddAutoMapper(typeof(ApiProfile));
        serviceCollection.AddAutoMapper(typeof(RepositoryProfile));
    }
}