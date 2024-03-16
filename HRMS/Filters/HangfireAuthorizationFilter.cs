using Hangfire.Dashboard;
using Microsoft.Extensions.Primitives;
using System.Net.Http.Headers;
using System.Text;

namespace HRMS.Filters;

public class HangfireAuthorizationFilter : IDashboardAuthorizationFilter
{
    public string ApiKey { get; set; } = string.Empty;

    public bool Authorize(DashboardContext context)
    {
        var httpContext = context.GetHttpContext();
        var header = httpContext.Request.Headers["Authorization"];

        if (string.IsNullOrWhiteSpace(header))
        {
            SetChallengeResponse(httpContext);
            return false;
        }

        var authValues = AuthenticationHeaderValue.Parse(header!);

        if (!authValues.Scheme.Equals("Basic", StringComparison.InvariantCultureIgnoreCase))
        {
            SetChallengeResponse(httpContext);
            return false;
        }

        var parameter = Encoding.UTF8.GetString(Convert.FromBase64String(authValues.Parameter!));
        var apiKey = parameter.Split(':')[0];

        if (apiKey.Equals(ApiKey)) return true;

        SetChallengeResponse(httpContext);
        return false;
    }

    private void SetChallengeResponse(HttpContext httpContext)
    {
        httpContext.Response.StatusCode = 401;
        httpContext.Response.Headers.Append("WWW-Authenticate", "Basic realm=\"Hangfire Dashboard\"");
        httpContext.Response.WriteAsync("Authentication is required.");
    }
}