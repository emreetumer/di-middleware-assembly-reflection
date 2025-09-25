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

// Service Provider. Middleware k�s�m� buras�. (Pipeline). Buran�n yaz�m s�ras� �nemli!
// A�a��daki s�ra neredeyse her projede kullan�lan olmas� gereken s�rad�r.
app.MapOpenApi();
app.MapScalarApiReference();
app.UseHttpsRedirection();
app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
app.UseStaticFiles();
app.UseRateLimiter();
app.UseAuthentication(); //giri� kontrol�
app.UseAuthorization(); //yetki kontrol�


app.MapControllers();
app.Run();


// Middleware = Api isteklerinde istek geldi�i andan itibaren araya giriyor, iste�i belli kontrollerden veya de�i�ikliklerden ge�irip bir sonrakine iletiyor. response olu�turup son kullan�c�ya iletiyor.
