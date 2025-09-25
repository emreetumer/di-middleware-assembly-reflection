namespace Middleware.WebAPI;

public class ExampleMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        // context üzerinden istediğimiz işlemler yapılır.

        await next(context);
    }
}
