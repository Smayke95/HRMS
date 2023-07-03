using HRMS.Core.Interfaces.Services;
using HRMS.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HRMS.Core.Extensions;

public static class ServiceExtensions
{
    public static void AddScopedServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<IEmailService, EmailService>();

        var services = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(x =>
                x.IsClass &&
                !x.IsAbstract &&
                x.Name.EndsWith("Service") &&
                !x.Name.Contains("EmailService")
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