using Hangfire;
using HRMS.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using HRMS.Extensions;

namespace HRMS.Filters;

[System.Diagnostics.CodeAnalysis.SuppressMessage("Minor Code Smell", "S3376:Attribute, EventArgs, and Exception type names should end with the type being extended", Justification = "<Pending>")]
public class ExceptionFilter : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        switch (context.Exception)
        {
            case ArgumentException:
                context.ModelState.AddModelError("Invalid parameter", context.Exception.Message);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                break;
            case InvalidOperationException:
                context.ModelState.AddModelError("Invalid operation", context.Exception.Message);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                break;
            default:
                context.ModelState.AddModelError("Server", "Server side error");
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                break;
        }

        var list = context
            .ModelState
            .Where(x => x.Value?.Errors.Count > 0)
            .ToDictionary(x => x.Key, y => y.Value?.Errors.Select(z => z.ErrorMessage));

        var status = context.HttpContext.Response.StatusCode;

        context.Result = new JsonResult(new { status, errors = list });

        BackgroundJob.Enqueue<IEmailService>(x => x.SendErrorMailAsync(context.Exception.ToEmailString(context.HttpContext.Request)));
    }
}