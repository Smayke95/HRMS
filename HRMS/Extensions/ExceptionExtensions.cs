using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace HRMS.Extensions;

public static class ExceptionExtensions
{
    public static string ToEmailString(this Exception exception, HttpRequest? request = null)
    {
        var result = new StringBuilder();

        result.Append("<h2><i style='color:red'>" + exception.Message + "</i></h2>");

        if (request is not null)
        {
            result.Append("<b>Request: </b>");
            result.Append(request.Method);
            result.Append("&nbsp;&nbsp;&nbsp; <b>Url: </b>https://");
            result.Append(request.Host + request.Path + request.QueryString);
            result.Append("<br/><br/>");
        }

        var stackTrace = new StackTrace(exception, true);
        var frame = stackTrace.GetFrame(0)!;
        var filename = frame.GetFileName();
        var line = frame.GetFileLineNumber();

        if (frame is not null && !filename.IsNullOrEmpty())
        {
            result.Append("<b>Source File: </b>");
            result.Append(filename);
            result.Append("&nbsp;&nbsp;&nbsp; <b>Line: </b>");
            result.Append(line);
            result.Append("<br/><br/>");
        }

        var namespaceName = exception.TargetSite?.DeclaringType?.Namespace ?? string.Empty;
        var className = exception.TargetSite?.DeclaringType?.Name ?? string.Empty;
        var methodName = exception.TargetSite?.Name ?? string.Empty;

        var isAsync = Array.Exists(
            exception.TargetSite?.DeclaringType?.GetInterfaces() ?? Array.Empty<Type>(),
            i => i == typeof(IAsyncStateMachine));

        if (isAsync)
        {
            var generatedType = exception.TargetSite!.DeclaringType;
            var originalType = generatedType!.DeclaringType;

            var foundMethod = originalType!
                .GetMethods()
                .SingleOrDefault(m => m.GetCustomAttribute<AsyncStateMachineAttribute>()?.StateMachineType == generatedType);

            if (foundMethod is not null)
            {
                className = foundMethod.DeclaringType!.Name;
                methodName = foundMethod.Name;
            }
        }

        result.Append("<b>Namespace: </b>");
        result.Append(namespaceName);
        result.Append("&nbsp;&nbsp;&nbsp; <b>Class: </b>");
        result.Append(className);
        result.Append("&nbsp;&nbsp;&nbsp; <b>Method: </b>");
        result.Append(methodName);
        result.Append("<br/><br/>");

        if (exception.InnerException is not null)
        {
            result.Append("<b>Inner Exception: </b><br/>");
            result.Append(exception.InnerException.Message);
            result.Append("<br/><br/>");
        }

        result.Append("<b>Stack Trace: </b><br/>");
        result.Append(exception.ToString().Replace("\r\n", "<br/>&nbsp;&nbsp;&nbsp;"));
        result.Append("<br/><br/><br/>");

        return result.ToString();
    }
}