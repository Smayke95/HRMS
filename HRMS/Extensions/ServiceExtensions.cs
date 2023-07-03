using HRMS.Database.Mappings;

namespace HRMS.Extensions;

public static class ServiceExtensions
{
    //public static void AddApiKeyAuthentication(this IServiceCollection serviceCollection)
    //{
    //    serviceCollection.AddAuthentication("ApiKeyAuthentication")
    //                     .AddScheme<AuthenticationSchemeOptions, ApiKeyAuthenticationHandler>("ApiKeyAuthentication", null);
    //}

    public static void AddAutoMapper(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddAutoMapper(typeof(RepositoryProfile));
    }
}