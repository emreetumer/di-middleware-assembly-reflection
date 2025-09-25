
// Inversion of Container = IoC 


var builder = WebApplication.CreateBuilder(args);// Bu yapý bize service collection üretiyor.

//SERVICE COLLECTION

// 1. Parça ihtiyaç duyulduðunda hangi classýn nereden ve nasýl instance türetileceðini bilgi olarak saklayan bir registration yapýsý / container




var app = builder.Build();  // Service Collection'ý => Service Provider'a dönüþtürüyor.

// SERVICE PROVIDER

// 2. Parça bu container'in execute esnasýnda o class istenirse instance türeten mekanizmasý




app.Run();
