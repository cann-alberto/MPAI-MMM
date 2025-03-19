using Microsoft.AspNetCore.Mvc;
using MMM_Server.Models;
using MMM_Server.Services;

namespace MMM_Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorController : ControllerBase
{
    private readonly UserService _usersService;

    public AuthorController(UserService usersService) 
    {
        _usersService = usersService;
    }

    //[HttpGet("users")]
    //public async Task<List<User>> Get() =>
    //    await _usersService.GetAsync();


}



