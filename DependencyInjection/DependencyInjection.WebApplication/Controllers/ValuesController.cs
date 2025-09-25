using DependencyInjection.Application;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjection.WebApplication.Controllers;

[ApiController]
[Route("/api/[Controller]")]
public class ValuesController : ControllerBase
{
    //private readonly Builder _builder;
    //private readonly Product _product;
    private readonly IProductService _productService;
    public ValuesController(/*Builder builder, Product product*/ IProductService productService)
    {
        //_builder = builder;
        //_product = product;
        _productService = productService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        //_builder.BuildHouse();
        return Ok();
    }
}
