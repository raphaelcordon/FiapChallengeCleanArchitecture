using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

[ApiController]
[Route("/")]
public class MainController : ControllerBase
{
    [HttpGet]
    public Task<IActionResult> Main()
    {
        return Task.FromResult<IActionResult>(Ok("API is up and running"));
    }
}