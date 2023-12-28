using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

public class FoodController : Controller
{
    public FoodController()
    {
        
    }
    
    [HttpGet("/food")]
    public IActionResult Food()
    {
        return View();
    }
    
}
