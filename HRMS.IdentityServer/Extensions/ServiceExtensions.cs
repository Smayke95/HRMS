using HRMS.Database.Mappings;
using HRMS.IdentityServer.Extensions;
using Serilog;

namespace HRMS.IdentityServer.Extensions;

public static class ServiceExtensions
{
    public static void AddAutoMapper(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddAutoMapper(typeof(RepositoryProfile));
    }

    public static void UseSerilog(this WebApplicationBuilder builder)
    {
        Log.Logger = new LoggerConfiguration()
            .ReadFrom
            .Configuration(builder.Configuration)
            .CreateLogger();

        builder.Host.UseSerilog();
    }
}