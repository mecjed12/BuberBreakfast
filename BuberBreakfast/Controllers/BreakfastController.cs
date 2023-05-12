using Microsoft.AspNetCore.Mvc;
using Buberbreakfast.Service.Breakfasts;
using Buberbreakfast.Service;
using Buberbreakfast.ServiceError;
using ErrorOr;

namespace Buberbreakfast.Controllers;

[ApiController]
[Route("[controller]")]
public class BreakfastController : ControllerBase
{
    private readonly IBreakfastService _breakfastService;

    public BreakfastController(IBreakfastService breakfastService)
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
        ErrorOr<Breakfast> getBreakFastResult = _breakfastService.GetBreakfast(id);

        if(getBreakFastResult.IsError &&
         getBreakFastResult.FirstError == Errors.Breakfast.NotFound)
        {
            return NotFound();
        }
        
       var breakfast = getBreakFastResult.Value;

       BreakfastResponse response = MapBreakfastResponse(breakfast);
       
       return Ok (response);
    }

    private static BreakfastResponse MapBreakfastResponse(Breakfast breakfast)
    {
        return new BreakfastResponse(
            breakfast.Id,
            breakfast.Name,
            breakfast.Description,
            breakfast.StartDatetime,
            breakfast.EndDatetime,
            breakfast.LastModifiedDateTime,
            breakfast.Savory,
            breakfast.Sweet
        );
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpsertBreakfast(Guid id, UpsertBreakfastRequest request)
    {
        var breakfast = new Breakfast(
            id,
            request.Name,
            request.Description,
            request.StartDateTime,
            request.EndDateTime,
            DateTime.UtcNow,
            request.Savory,
            request.Sweet);

        _breakfastService.UpsertBreakfast(breakfast);
        return NoContent();
    }

    [HttpDelete()]
    public IActionResult DeleteBreakfsat(Guid id)
    {
        _breakfastService.DeleteBreakfast(id);
        return NoContent() ;
    }

   

    private class Giud
    {
        internal static Guid NewGuid()
        {
            throw new NotImplementedException();
        }
    }
}