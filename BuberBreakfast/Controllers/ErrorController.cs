using Microsoft.AspNetCore.Mvc;

namespace Buberbreakfast.Controllers;

public class ErrorController : ControllerBase
{
    [Route("/error")]
    public IActionResult Error()
    {
        return Problem();
    } 
}