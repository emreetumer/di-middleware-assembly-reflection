using Microsoft.AspNetCore.RateLimiting;
using Middleware.WebAPI;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Service Collection
builder.Services.AddControllers();
builder.Services.AddCors();
builder.Services.AddOpenApi();
builder.Services.AddRateLimiter(conf =>
{
    conf.AddFixedWindowLimiter("fixed", (opt) =>
    {
        opt.Window = TimeSpan.FromSeconds(1);
    });
});
builder.Services.AddTransient<ExampleMiddleware>(); // custom middleware baþka sýnýftan çaðýrmak için yazýyoruz aþaðýya da ekleyeceðiz.
builder.Services.AddExceptionHandler<ExceptionHandler>().AddProblemDetails(); //ExceptionHandler için eklenen yapý. aþaðýdada yapacaðýz.


var app = builder.Build();

// Service Provider. Middleware kýsýmý burasý. (Pipeline). Buranýn yazým sýrasý önemli!
// Aþaðýdaki sýra neredeyse her projede kullanýlan olmasý gereken sýradýr.
app.MapOpenApi();
app.MapScalarApiReference();
app.UseHttpsRedirection();
app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
app.UseStaticFiles();
app.UseRateLimiter();
app.UseAuthentication(); //giriþ kontrolü
app.UseAuthorization(); //yetki kontrolü

app.UseExceptionHandler();

app.UseMiddleware<ExampleMiddleware>(); // custom middlewareyi baþka sýnýftan çaðýrmak için yazdýk.
// custom middleware buraya yazýlýr.
//app.Use(async (context, next) =>
//{
//    await next(context);
//});

app.MapControllers();
app.Run();


// Middleware = Api isteklerinde istek geldiði andan itibaren araya giriyor, isteði belli kontrollerden veya deðiþikliklerden geçirip bir sonrakine iletiyor. response oluþturup son kullanýcýya iletiyor.
