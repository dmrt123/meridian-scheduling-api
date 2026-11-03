namespace Scheduling.Api.Errors;

/// <summary>The shared error envelope every Meridian API returns.</summary>
public sealed record ApiError(string Code, string Message, string CorrelationId)
{
    public static IResult Result(int status, string code, string message, HttpContext context) =>
        Results.Json(new { error = new ApiError(code, message, context.TraceIdentifier) }, statusCode: status);
}
