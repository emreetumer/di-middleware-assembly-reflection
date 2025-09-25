
// Inversion of Container = IoC 


var builder = WebApplication.CreateBuilder(args);// Bu yapý bize service collection üretiyor.

//SERVICE COLLECTION

// 1. Parça ihtiyaç duyulduðunda hangi classýn nereden ve nasýl instance türetileceðini bilgi olarak saklayan bir registration yapýsý / container


builder.Services.AddTransient<Cekic>(); // dependency injection yapýlacak classýn ctor'unda istenmesi lazým bunun için.
builder.Services.AddTransient<Civi>();  // dependency injection yapýlacak classýn ctor'unda istenmesi lazým bunun için.
builder.Services.AddTransient<Builder>();  // dependency injection yapýlacak classýn ctor'unda istenmesi lazým bunun için.



var app = builder.Build();  // Service Collection'ý => Service Provider'a dönüþtürüyor.

// SERVICE PROVIDER

// 2. Parça bu container'in execute esnasýnda o class istenirse instance türeten mekanizmasý

app.MapGet("/test", (Builder builder) =>
{
    builder.BuildHouse();
    return Results.Ok();
});



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
