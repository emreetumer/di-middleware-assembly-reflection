
// Inversion of Container = IoC 


var builder = WebApplication.CreateBuilder(args);// Bu yap� bize service collection �retiyor.

//SERVICE COLLECTION

// 1. Par�a ihtiya� duyuldu�unda hangi class�n nereden ve nas�l instance t�retilece�ini bilgi olarak saklayan bir registration yap�s� / container




var app = builder.Build();  // Service Collection'� => Service Provider'a d�n��t�r�yor.

// SERVICE PROVIDER

// 2. Par�a bu container'in execute esnas�nda o class istenirse instance t�reten mekanizmas�




app.Run();
