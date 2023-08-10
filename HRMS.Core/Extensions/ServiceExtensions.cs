using HRMS.Core.Interfaces.Services;
using HRMS.Core.Models.Enums;
using HRMS.Core.Services;
using HRMS.Core.States.EmployeePositionStates;
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

    public static void AddScopedStates(this IServiceCollection serviceCollection)
    {
        var states = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(x =>
                x.IsClass &&
                !x.IsAbstract &&
                x.Name.EndsWith("State")
             );

        foreach (var state in states)
            serviceCollection.AddScoped(state);

        serviceCollection.AddScoped<EmployeePositionStateResolver>(services => employmentStatus =>
        {
            switch (employmentStatus)
            {
                case EmploymentStatus.Initial:
                    return services.GetService<EmployeePositionInitialState>();
                case EmploymentStatus.Inactive:
                    return services.GetService<EmployeePositionInactiveState>();
                case EmploymentStatus.Active:
                    return services.GetService<EmployeePositionActiveState>();
                default:
                    return services.GetService<EmployeePositionBaseState>();
            }
        });
    }
}