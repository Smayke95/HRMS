using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HRMS.RabbitMQ.Extensions;

public static class ServiceExtensions
{
    public static void AddScopedNotificationServices(this IServiceCollection serviceCollection)
    {
        var services = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(x =>
                x.IsClass &&
                !x.IsAbstract &&
                x.Name.EndsWith("Service")
             );

        foreach (var service in services)
        {
            var interfaces = service
                .GetInterfaces()
                .Where(x => !x.IsGenericType);

            foreach (var inter in interfaces)
                serviceCollection.AddScoped(inter, service);
        }
    }
}