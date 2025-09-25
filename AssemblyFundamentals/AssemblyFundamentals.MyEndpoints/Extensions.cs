using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AssemblyFundamentals.MyEndpoints;
public static class Extensions
{
    public static void AddMyEndpoints(this IServiceCollection services, Assembly assembly)
    {
        var types = assembly
            .GetTypes()
            .Where(i =>
            typeof(IEndpoint).IsAssignableFrom(i)
            && i.IsClass
            && !i.IsAbstract
            );

        foreach (var type in types)
        {
            services.AddTransient(typeof(IEndpoint), type);
        }
    }

    public static void MapEndpoints(this IEndpointRouteBuilder app)
    {
        var modules = app.ServiceProvider.GetServices<IEndpoint>();
        foreach (var module in modules)
        {
            module.MapEndpoints(app);
        }
    }
}
