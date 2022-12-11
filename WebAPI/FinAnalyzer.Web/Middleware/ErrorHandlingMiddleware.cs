using FinAnalyzer.Common;
using StafferyInternal.StafferyInternal.Common;
using System.Net;
using System.Text.Json;

namespace StafferyInternal.StafferyInternal.Web.Middleware;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;

    public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, "An exception occured while processing HTTP request: {Message}", exception.Message);
            await HandleExceptionAsync(context, exception);
        }

    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var code = (int)HttpStatusCode.InternalServerError;
        var contentType = context.Request.ContentType ?? "application/json";
        context.Response.ContentType = contentType;
        context.Response.StatusCode = code;
        string body = JsonSerializer.Serialize(
            OperationResult.Fail(OperationCode.UnhandledError, exception.Message, exception.StackTrace)
        );

        return context.Response.WriteAsync(body);
    }
}
