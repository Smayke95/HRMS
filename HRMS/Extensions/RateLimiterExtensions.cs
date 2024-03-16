using System.Threading.RateLimiting;

namespace HRMS.Extensions;

public static class RateLimiterExtensions
{
    public static void AddRateLimiter(this IServiceCollection services)
    {
        services.AddRateLimiter(options =>
        {
            options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;

            options.AddPolicy("FixedPolicy", httpContext =>
            {
                return RateLimitPartition.GetFixedWindowLimiter("Api", x => new FixedWindowRateLimiterOptions
                {
                    PermitLimit = 10000,
                    Window = TimeSpan.FromHours(1)
                });
            });
        });
    }
}