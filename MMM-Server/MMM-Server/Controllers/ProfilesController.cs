using MMM_Server.Models;
using MMM_Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace MMM_Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfilesController: ControllerBase
{
    private readonly ProfileService _profilesService;
    public ProfilesController(ProfileService profilesService) =>
        _profilesService = profilesService;

    [HttpGet]
    public async Task<List<Profile>> Get() =>
        await _profilesService.GetAsync();

}
