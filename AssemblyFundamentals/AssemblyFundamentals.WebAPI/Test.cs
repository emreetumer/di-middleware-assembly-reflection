using System.Reflection;

namespace AssemblyFundamentals.WebAPI;

public class Test
{
    public string Name { get; set; } = "Emre Tümer";
    public int Age { get; set; } = 24;
    public void Method()
    {
        Console.WriteLine("I am working..");
    }
}

public class AssemblyTest
{
    public void Method()
    {
        //Buraya breakporit koyup derleyince assembly içindekileri görüyoruz.
        var assembly = Assembly.GetExecutingAssembly();
    }
}