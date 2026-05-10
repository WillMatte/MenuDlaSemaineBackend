using Backend.Domain;
using Backend.Domain.Exception;
using Microsoft.AspNetCore.Diagnostics;

namespace Backend.Api.ExceptionMapper;

public class GlobalExceptionMapper : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext context,
        Exception exception,
        CancellationToken cancellationToken)
    {
        var (statusCode, message) = exception switch
        {
            EmailFormatException e      => (StatusCodes.Status400BadRequest, e.Message),
            PasswordFormatException e   => (StatusCodes.Status400BadRequest, e.Message),
            DulplicateEmailException e  => (StatusCodes.Status409Conflict, e.Message),
            _                           => (StatusCodes.Status500InternalServerError, "An unexpected error occurred")
        };

        context.Response.StatusCode = statusCode;

        await context.Response.WriteAsJsonAsync(new
        {
            statusCode,
            message
        }, cancellationToken);

        return true; // true = exception is handled, stop propagation
    }
}