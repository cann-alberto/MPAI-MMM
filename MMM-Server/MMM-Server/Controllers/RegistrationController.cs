using MMM_Server.Models;
using MMM_Server.Services;
using Microsoft.AspNetCore.Mvc;


namespace MMM_Server.Controllers;

[ApiController]
[Route("api/[controller]/profiles")]
public class RegistrationController : ControllerBase
{
    
    private readonly PersonalProfileService _personalProfilesService;
    
    public RegistrationController(PersonalProfileService profilesService) =>
        _personalProfilesService = profilesService;

    [HttpGet]
    public async Task<List<PersonalProfile>> Get() =>
        await _personalProfilesService.GetAsync();

    [HttpPost]
    public async Task<IActionResult> Post(PersonalProfile newPersonalProfile)
    {
        await _personalProfilesService.CreateAsync(newPersonalProfile);

        return CreatedAtAction(nameof(Get), new { id = newPersonalProfile.Id }, newPersonalProfile);
    }
}





