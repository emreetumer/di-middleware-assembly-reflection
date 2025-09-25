
// Inversion of Container = IoC 


var builder = WebApplication.CreateBuilder(args);// Bu yap� bize service collection �retiyor.

//SERVICE COLLECTION

// 1. Par�a ihtiya� duyuldu�unda hangi class�n nereden ve nas�l instance t�retilece�ini bilgi olarak saklayan bir registration yap�s� / container


builder.Services.AddTransient<Cekic>(); // dependency injection yap�lacak class�n ctor'unda istenmesi laz�m bunun i�in.
builder.Services.AddTransient<Civi>();  // dependency injection yap�lacak class�n ctor'unda istenmesi laz�m bunun i�in.
builder.Services.AddTransient<Builder>();  // dependency injection yap�lacak class�n ctor'unda istenmesi laz�m bunun i�in.



var app = builder.Build();  // Service Collection'� => Service Provider'a d�n��t�r�yor.

// SERVICE PROVIDER

// 2. Par�a bu container'in execute esnas�nda o class istenirse instance t�reten mekanizmas�

app.MapGet("/test", (Builder builder) =>
{
    builder.BuildHouse();
    return Results.Ok();
});



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
