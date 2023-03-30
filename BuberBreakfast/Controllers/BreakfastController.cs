
using Microsoft.AspNetCore.Mvc;


namespace Buberbreakfast.Controllers;

[ApiController]
[Route("[controller]")]
public class BreakfastController : ControllerBase
{
    [HttpPost()]
    public IActionResult CreateBreakfast(CreateBreakfastRequest request)
    {
        return Ok (request);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetBreakfast(Guid id)
    {
        return Ok (id);
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpsertBreakfast(Guid id, UpsertBreakfastRequest request)
    {
        return Ok (request);
    }

    [HttpDelete()]
    public IActionResult DeleteBreakfsat(Guid id)
    {
        return Ok (id);
    }

    

}