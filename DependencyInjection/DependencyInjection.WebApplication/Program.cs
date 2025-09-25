
// Inversion of Container = IoC 


using DependencyInjection.Application;
using DependencyInjection.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);// Bu yap� bize service collection �retiyor.

//SERVICE COLLECTION

// 1. Par�a ihtiya� duyuldu�unda hangi class�n nereden ve nas�l instance t�retilece�ini bilgi olarak saklayan bir registration yap�s� / container

builder.Services.AddControllers(); // 1) Ben controller yap�s� kullanaca��m bunu ihtiya� duyarsan bu yap�ya g�re instance �ret demek(daha instance �retilmedi sadece not olarak ekledi.)

builder.Services.AddScoped<IProductService, ProductService>(); // Bu i�leme Service registration denir.

builder.Services.AddTransient<Product>();
builder.Services.AddTransient<Cekic>(); // dependency injection yap�lacak class�n ctor'unda istenmesi laz�m bunun i�in.
builder.Services.AddTransient<Civi>();  // dependency injection yap�lacak class�n ctor'unda istenmesi laz�m bunun i�in.
builder.Services.AddTransient<Builder>();  // dependency injection yap�lacak class�n ctor'unda istenmesi laz�m bunun i�in.


//AddTransient : Her istekte ayr� instance �retir. Her ihtiya� duyuldu�unda yeniden �retir.
//AddScoped : �stek ba��ndan istek sonuna kadar tek bir instance kullan�r.
//AddSingleton : �lk �a��r�ld���nda instance �retilir daha sonras�nda uygulama sonlanana kadar ayn� instance kullan�r.


var app = builder.Build();  // Service Collection'� => Service Provider'a d�n��t�r�yor.

// SERVICE PROVIDER

// 2. Par�a bu container'in execute esnas�nda o class istenirse instance t�reten mekanizmas�

app.MapGet("/test", (Builder b /*ctor gibi �al���r*/) =>
{
    // CTOR' DA PARAMETRE VERMEDEN BU A�A�IDAK� KODLARI YAZARSAK SORUN OLMAZ AMA CTOR'a BUILDERI VERD���M�ZDE B�Z�M YER�M�ZE SERVICE PROVIDER SA�LAR A�A�IDAK� 3 SATIR KODU.
    //var cekic = app.Services.GetService<Cekic>();
    //var civi = app.Services.GetService<Civi>();
    //var b = new Builder(cekic, civi);

    b.BuildHouse();
    return Results.Ok();
});

app.MapControllers(); // 1) class� newlemesi gerekti�ini burada anl�yor.


app.Run();


// Buradan sonrakiler �rnek i�in

public class Civi //Dependency
{
    public int Num { get; set; } = 0;
    public Civi()
    {

    }
    public void Use()
    {
        Console.WriteLine("Civi kullan�ld�.");
    }
}

public class Cekic // Dependency
{
    public Cekic()
    {

    }
    public void Use()
    {
        Console.WriteLine("Cekic kullan�ld�.");
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

        Console.WriteLine("Ev in�a edildi");
    }
}
public class Product
{
    public Product(Civi civi)
    {
        civi.Num += 7;
        Console.WriteLine("�ivi num: {0}", civi.Num);
    }
}