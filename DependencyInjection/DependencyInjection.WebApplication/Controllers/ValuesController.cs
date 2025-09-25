using Microsoft.AspNetCore.Mvc;

namespace DependencyInjection.WebApplication.Controllers;

[ApiController]
[Route("/api/[Controller]")]
public class ValuesController : ControllerBase
{
    private readonly Builder _builder;
    private readonly Product _product;
    public ValuesController(Builder builder, Product product)
    {
        _builder = builder;
        _product = product;
    }

    [HttpGet]
    public IActionResult Get()
    {
        _builder.BuildHouse();
        return Ok();
    }
}
