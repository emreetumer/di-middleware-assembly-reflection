using Microsoft.AspNetCore.Diagnostics;

namespace Middleware.WebAPI;

public class ExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        var res = new { Message = exception.Message };
        httpContext.Response.StatusCode = 400; // opsiyonel
        await httpContext.Response.WriteAsJsonAsync(res);

        // await httpContext.Response.WriteAsync(exception.Message); //bu şekilde direkt string dönüyor biz best pratics json olması
        return true;
    }
}
