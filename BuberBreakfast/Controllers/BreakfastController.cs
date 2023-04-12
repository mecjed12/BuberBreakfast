using Microsoft.AspNetCore.Mvc;
using Buberbreakfast.Service.Breakfasts;
using Buberbreakfast.Service;


namespace Buberbreakfast.Controllers;

[ApiController]
[Route("[controller]")]
public class BreakfastController : ControllerBase
{
    private readonly IBreakfastService _breakfastService;

    private BreakfastController(IBreakfastService breakfastService)
    {
        _breakfastService = breakfastService;
    }

    [HttpPost]
    public IActionResult CreateBreakfast(CreateBreakfastRequest request)
    {
        var breakfast = new Breakfast(
            Guid.NewGuid(),
            request.Name,
            request.Description,
            request.StartDateTime,
            request.EndDateTime,
            DateTime.UtcNow,
            request.Savory,
            request.Sweet);

        _breakfastService.CreateBreakfast(breakfast);

        var response = new BreakfastResponse(
            breakfast.Id,
            breakfast.Name,
            breakfast.Description,
            breakfast.StartDatetime,
            breakfast.EndDatetime,
            breakfast.LastModifiedDateTime,
            breakfast.Savory,
            breakfast.Sweet);
                    
        return CreatedAtAction (
            actionName: nameof(GetBreakfast),
            routeValues: new {id = breakfast.Id },
            value: response);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetBreakfast(Guid id)
    {
        Breakfast breakfast = _breakfastService.GetBreakfast(id);
        
       var response = new BreakfastResponse(
            breakfast.Id,
            breakfast.Name,
            breakfast.Description,
            breakfast.StartDatetime,
            breakfast.EndDatetime,
            breakfast.LastModifiedDateTime,
            breakfast.Savory,
            breakfast.Sweet);
        return Ok (response);
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

    private interface IBreakfastService
    {
        void CreateBreakfast(Breakfast breakfast);
        Breakfast GetBreakfast(Guid id);
    }

    private class Giud
    {
        internal static Guid NewGuid()
        {
            throw new NotImplementedException();
        }
    }
}