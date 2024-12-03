using Microsoft.AspNetCore.Mvc;
using MMM_Server.Models;
using MMM_Server.Services;

namespace MMM_Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ActivityController: ControllerBase
{
    private readonly UserService _usersService;

    public ActivityController(UserService usersService)
    {
        _usersService = usersService;

    }

    [HttpGet("profiles")]
    public async Task<List<User>> Get() =>
        await _usersService.GetAsync();

}








