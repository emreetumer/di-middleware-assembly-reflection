using AssemblyFundamentals.MyEndpoints;
using Scalar.AspNetCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//AssemblyTest assemblyTest = new();
//assemblyTest.Method();

builder.Services.AddOpenApi();

builder.Services.AddMyEndpoints
    (Assembly.GetExecutingAssembly());


var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapOpenApi();
app.MapScalarApiReference();


//app.MapProducts();
//app.MapCategories();

app.MapEndpoints();

app.Run();
