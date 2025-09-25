using AssemblyFundamentals.MyEndpoints;

namespace AssemblyFundamentals.WebAPI.Modules;

public class ProductModule : IEndpoint
{
    public void MapEndpoints(IEndpointRouteBuilder builder)
    {
        var app = builder.MapGroup("products").WithTags("Products");

        app.MapGet(string.Empty, () => { });
        app.MapPost(string.Empty, () => { });
        app.MapPut(string.Empty, () => { });
        app.MapDelete(string.Empty, () => { });
    }
}

public class CategoryModule : IEndpoint
{
    public void MapEndpoints(IEndpointRouteBuilder builder)
    {
        var app = builder.MapGroup("categories").WithTags("Categories");

        app.MapGet(string.Empty, () => { });
        app.MapPost(string.Empty, () => { });
        app.MapPut(string.Empty, () => { });
        app.MapDelete(string.Empty, () => { });
    }
}

public class BasketModule : IEndpoint
{
    public void MapEndpoints(IEndpointRouteBuilder builder)
    {
        var app = builder.MapGroup("baskets").WithTags("Baskets");

        app.MapGet(string.Empty, () => { });
        app.MapPost(string.Empty, () => { });
        app.MapPut(string.Empty, () => { });
        app.MapDelete(string.Empty, () => { });
    }
}
