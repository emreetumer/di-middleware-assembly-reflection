using Microsoft.Extensions.DependencyInjection;
using Scrutor;

namespace DependencyInjection.Infrastructure;
public static class ServiceRegistrar
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        //services.AddScoped<IProductService, ProductService>(); 

        services.Scan(action => action
        .FromAssemblies(typeof(ServiceRegistrar).Assembly)
        .AddClasses(publicOnly: false)
        .UsingRegistrationStrategy(RegistrationStrategy.Skip)
        .AsImplementedInterfaces()
        .WithScopedLifetime()
        );
        //Bu üstteki kod scrutor kütüphanesi tarafından interfaceli dependency injection yapmanın kolay hali yani 100lerce  services.AddScoped<IProductService, ProductService>(); buna benzer kod yerine bu kodu yazarak otomatik algılamasını sağlıyor.  
        return services;
    }
}

//Bu yapı program cs ye yazmak istemessek böyle oluşturulabilir. Program cs de services.addscoped<AddInfrastructre> çağırmamız lazım (Extension method)
