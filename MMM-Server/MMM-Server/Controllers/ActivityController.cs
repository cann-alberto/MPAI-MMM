using Microsoft.AspNetCore.Mvc;
using MMM_Server.Models;
using MMM_Server.Services;

namespace MMM_Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ActivityController: ControllerBase
{
    private readonly UserService _usersService;
    private readonly ActionRequestService _actionsService;

    public ActivityController(UserService usersService, ActionRequestService actionService)
    {
        _usersService = usersService;
        _actionsService = actionService;
    }

    [HttpGet("users")]
    public async Task<List<User>> Get() =>
        await _usersService.GetAsync();

    [HttpGet("logins")]
    public async Task<List<ActionRequest>> GetActions() =>
        await _actionsService.GetAsync();

    [HttpPost("logins")]
    public async Task<IActionResult> Post(ActionRequest newAction)
    {
        await _actionsService.CreateAsync(newAction);

        return CreatedAtAction(nameof(Get), new { id = newAction.ActionRequestID }, newAction);
    }

}








