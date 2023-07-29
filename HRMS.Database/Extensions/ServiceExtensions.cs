using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HRMS.Database.Extensions;

public static class ServiceExtensions
{
    public static void AddDbContext(this IServiceCollection services, string connectionString) =>
        services.AddDbContext<Context>(options =>
            options.UseSqlServer(connectionString)
                   .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
        );

    public static void DatabaseMigrate(this IServiceProvider service)
    {
        using var scope = service.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<Context>();
        context.Database.Migrate();
    }

    public static void AddScopedRepositories(this IServiceCollection serviceCollection)
    {
        var repositories = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(x =>
                x.IsClass &&
                !x.IsAbstract &&
                x.Name.EndsWith("Repository")
             );

        foreach (var repository in repositories)
        {
            var interfaces = repository
                .GetInterfaces()
                .Where(x => !x.IsGenericType);

            foreach (var inter in interfaces)
                serviceCollection.AddScoped(inter, repository);
        }
    }
}