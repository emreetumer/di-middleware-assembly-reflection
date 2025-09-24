var cekic = new Cekic();
var civi = new Civi();
Builder builder = new Builder(cekic, civi);
builder.BuildHouse();

class Civi //Dependency
{
    public void Use()
    {
        Console.WriteLine("Civi kullanıldı.");
    }
}

class Cekic // Dependency
{
    public void Use()
    {
        Console.WriteLine("Cekic kullanıldı.");
    }
}

class Builder
{
    Cekic _cekic;
    Civi _civi;
    public Builder(Cekic cekic, Civi civi)
    {
        _civi = civi;
        _cekic = cekic;
    }

    public void BuildHouse()
    {
        //Cekic cekic = new Cekic();
        //cekic.Use();
        //Civi civi = new Civi();
        //civi.Use();

        _cekic.Use();
        _civi.Use();

        Console.WriteLine("Ev inşa edildi");
    }
}