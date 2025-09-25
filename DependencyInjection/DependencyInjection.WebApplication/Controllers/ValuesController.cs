using Microsoft.AspNetCore.Mvc;

namespace DependencyInjection.WebApplication.Controllers;

[ApiController]
[Route("/api/[Controller]")]
public class ValuesController : ControllerBase
{
    private readonly Builder _builder;
    public ValuesController(Builder builder)
    {
        _builder = builder;
    }

    [HttpGet]
    public IActionResult Get()
    {
        _builder.BuildHouse();
        return Ok();
    }
}
