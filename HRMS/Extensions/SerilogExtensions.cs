using Serilog;

namespace HRMS.Extensions;

public static class SerilogExtensions
{
    public static void UseSerilog(this WebApplicationBuilder builder)
    {
        Log.Logger = new LoggerConfiguration()
            .ReadFrom
            .Configuration(builder.Configuration)
            .CreateLogger();

        builder.Host.UseSerilog();
    }
}