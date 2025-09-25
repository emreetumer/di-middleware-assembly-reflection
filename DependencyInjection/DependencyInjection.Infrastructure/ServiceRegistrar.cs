using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection.Infrastructure;
public static class ServiceRegistrar
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        //services.AddScoped<IProductService, ProductService>(); 
        return services;
    }
}

//Bu yapı program cs ye yazmak istemessek böyle oluşturulabilir. Program cs de services.addscoped<AddInfrastructre> çağırmamız lazım (Extension method)
