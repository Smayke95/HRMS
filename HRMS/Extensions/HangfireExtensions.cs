using Hangfire;
using Hangfire.SqlServer;
using HRMS.Core.Interfaces.Services;
using HRMS.Extensions;
using HRMS.Filters;

namespace HRMS.Extensions;

public static class HangfireExtensions
{
    public static void AddHangfire(this IServiceCollection services, string connectionString)
    {
        services.AddHangfire(configuration => configuration
            .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
            .UseSimpleAssemblyNameTypeSerializer()
            .UseRecommendedSerializerSettings()
            .UseSqlServerStorage(
                connectionString,
                new SqlServerStorageOptions
                {
                    CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                    SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                    QueuePollInterval = TimeSpan.Zero,
                    UseRecommendedIsolationLevel = true,
                    DisableGlobalLocks = true
                }
            )
            .WithJobExpirationTimeout(TimeSpan.FromDays(7)));

        services.AddHangfireServer();
    }

    public static void UseHangfireDashboard(this IApplicationBuilder app, IConfiguration configuration)
    {
        var options = new DashboardOptions
        {
            AppPath = "/swagger",
            DashboardTitle = "HRMS Hangfire",
            Authorization = new[] { new HangfireAuthorizationFilter { ApiKey = configuration.GetSection("HangfireKey").Value! } }
        };

        app.UseHangfireDashboard("/hangfire", options);

        AddHangfireRecurringJobs();
    }

    private static void AddHangfireRecurringJobs()
    {
        GlobalJobFilters.Filters.Add(new AutomaticRetryAttribute { Attempts = 1 });

        RecurringJob.AddOrUpdate<INotificationService>("Take a break", x => x.TakeBreak(), Cron.Hourly);
    }
}