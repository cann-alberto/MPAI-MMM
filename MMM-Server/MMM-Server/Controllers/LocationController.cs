using Microsoft.AspNetCore.Mvc;
using MMM_Server.Models;
using MMM_Server.Services;


namespace MMM_Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LocationController : ControllerBase
{
    private readonly ActionRequestService _actionRequestService;
       
    public LocationController(ActionRequestService actionRequestService)
    {
        _actionRequestService = actionRequestService;        
    }

    [HttpGet("action-requests")]
    public async Task<List<ActionRequest>> Get() =>
       await _actionRequestService.GetAsync();

    [HttpPost("action-request")]
    public async Task<IActionResult> Post(ActionRequest newActionRequest)
    {
        await _actionRequestService.CreateAsync(newActionRequest);

        return CreatedAtAction(nameof(Get), new { id = newActionRequest.ActionRequestID }, newActionRequest);
    }

}