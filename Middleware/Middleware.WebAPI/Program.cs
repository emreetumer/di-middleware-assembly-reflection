using Microsoft.AspNetCore.RateLimiting;
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


app.MapControllers();
app.Run();


// Middleware = Api isteklerinde istek geldiði andan itibaren araya giriyor, isteði belli kontrollerden veya deðiþikliklerden geçirip bir sonrakine iletiyor. response oluþturup son kullanýcýya iletiyor.
