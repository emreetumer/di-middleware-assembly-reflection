using Microsoft.AspNetCore.Mvc;

namespace Middleware.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ValuesController : ControllerBase
{
    [HttpGet]
    public IActionResult Method(string name)
    {
        throw new ArgumentException("bla bla");
        return Ok();
    }
}
