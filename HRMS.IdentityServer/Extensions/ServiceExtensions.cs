using HRMS.Database.Mappings;
using HRMS.IdentityServer.Extensions;

namespace HRMS.IdentityServer.Extensions;

public static class ServiceExtensions
{
    public static void AddAutoMapper(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddAutoMapper(typeof(RepositoryProfile));
    }
}