
// Inversion of Container = IoC 


using DependencyInjection.Application;
using DependencyInjection.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);// Bu yapý bize service collection üretiyor.

//SERVICE COLLECTION

// 1. Parça ihtiyaç duyulduðunda hangi classýn nereden ve nasýl instance türetileceðini bilgi olarak saklayan bir registration yapýsý / container

builder.Services.AddControllers(); // 1) Ben controller yapýsý kullanacaðým bunu ihtiyaç duyarsan bu yapýya göre instance üret demek(daha instance üretilmedi sadece not olarak ekledi.)

builder.Services.AddScoped<IProductService, ProductService>(); // Bu iþleme Service registration denir.

builder.Services.AddTransient<Product>();
builder.Services.AddTransient<Cekic>(); // dependency injection yapýlacak classýn ctor'unda istenmesi lazým bunun için.
builder.Services.AddTransient<Civi>();  // dependency injection yapýlacak classýn ctor'unda istenmesi lazým bunun için.
builder.Services.AddTransient<Builder>();  // dependency injection yapýlacak classýn ctor'unda istenmesi lazým bunun için.


//AddTransient : Her istekte ayrý instance üretir. Her ihtiyaç duyulduðunda yeniden üretir.
//AddScoped : Ýstek baþýndan istek sonuna kadar tek bir instance kullanýr.
//AddSingleton : Ýlk çaðýrýldýðýnda instance üretilir daha sonrasýnda uygulama sonlanana kadar ayný instance kullanýr.


var app = builder.Build();  // Service Collection'ý => Service Provider'a dönüþtürüyor.

// SERVICE PROVIDER

// 2. Parça bu container'in execute esnasýnda o class istenirse instance türeten mekanizmasý

app.MapGet("/test", (Builder b /*ctor gibi çalýþýr*/) =>
{
    // CTOR' DA PARAMETRE VERMEDEN BU AÞAÐIDAKÝ KODLARI YAZARSAK SORUN OLMAZ AMA CTOR'a BUILDERI VERDÝÐÝMÝZDE BÝZÝM YERÝMÝZE SERVICE PROVIDER SAÐLAR AÞAÐIDAKÝ 3 SATIR KODU.
    //var cekic = app.Services.GetService<Cekic>();
    //var civi = app.Services.GetService<Civi>();
    //var b = new Builder(cekic, civi);

    b.BuildHouse();
    return Results.Ok();
});

app.MapControllers(); // 1) classý newlemesi gerektiðini burada anlýyor.


app.Run();


// Buradan sonrakiler örnek için

public class Civi //Dependency
{
    public int Num { get; set; } = 0;
    public Civi()
    {

    }
    public void Use()
    {
        Console.WriteLine("Civi kullanýldý.");
    }
}

public class Cekic // Dependency
{
    public Cekic()
    {

    }
    public void Use()
    {
        Console.WriteLine("Cekic kullanýldý.");
    }
}

public class Builder
{
    Cekic _cekic;
    Civi _civi;
    public Builder(Cekic cekic, Civi civi)
    {
        _civi = civi;
        _cekic = cekic;

        civi.Num = 5;
    }

    public void BuildHouse()
    {
        //Cekic cekic = new Cekic();
        //cekic.Use();
        //Civi civi = new Civi();
        //civi.Use();

        _cekic.Use();
        _civi.Use();

        Console.WriteLine("Ev inþa edildi");
    }
}
public class Product
{
    public Product(Civi civi)
    {
        civi.Num += 7;
        Console.WriteLine("Çivi num: {0}", civi.Num);
    }
}