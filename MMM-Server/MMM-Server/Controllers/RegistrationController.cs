using MMM_Server.Models;
using MMM_Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace MMM_Server.Controllers;

[ApiController]
[Route("api/[controller]/profiles")]
public class RegistrationController : ControllerBase
{
    
    private readonly ProfileService _profilesService;
    
    public RegistrationController(ProfileService profilesService) =>
        _profilesService = profilesService;

    [HttpGet]
    public async Task<List<Profile>> Get() =>
        await _profilesService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Profile>> Get(string id)
    {
        var book = await _profilesService.GetAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        return book;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Profile newProfile)
    {
        await _profilesService.CreateAsync(newProfile);

        return CreatedAtAction(nameof(Get), new { id = newProfile.Id }, newProfile);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Profile updatedProfile)
    {
        var profile = await _profilesService.GetAsync(id);

        if (profile is null)
        {
            return NotFound();
        }

        updatedProfile.Id = profile.Id;

        await _profilesService.UpdateAsync(id, updatedProfile);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var profile = await _profilesService.GetAsync(id);

        if (profile is null)
        {
            return NotFound();
        }

        await _profilesService.RemoveAsync(id);

        return NoContent();
    }

}





