using Microsoft.AspNetCore.Routing;

namespace AssemblyFundamentals.MyEndpoints;
public interface IEndpoint
{
    void MapEndpoints(IEndpointRouteBuilder builder);

}
