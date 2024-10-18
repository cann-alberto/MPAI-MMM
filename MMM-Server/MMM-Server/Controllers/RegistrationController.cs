using MMM_Server.Models;
using MMM_Server.Services;
using Microsoft.AspNetCore.Mvc;


namespace MMM_Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RegistrationController : ControllerBase
{

    private readonly PersonalProfileService _personalProfilesService;
    private readonly UserService _usersService;
    private readonly PersonaService _personaeService;
    private readonly DeviceService _devicesService;

    public RegistrationController(PersonalProfileService profilesService, UserService usersService, PersonaService personaeService, DeviceService devicesService)
    {
        _personalProfilesService = profilesService;
        _usersService = usersService;
        _personaeService = personaeService;
        _devicesService = devicesService;
    }

    [HttpGet("profiles")]
    public async Task<List<PersonalProfile>> Get() =>
        await _personalProfilesService.GetAsync();

    [HttpPost("profiles")]
    public async Task<IActionResult> Post(PersonalProfile newPersonalProfile)
    {
        await _personalProfilesService.CreateAsync(newPersonalProfile);

        return CreatedAtAction(nameof(Get), new { id = newPersonalProfile.Id }, newPersonalProfile);
    }

    [HttpPost ("users")]
    public async Task<IActionResult> Post(User newUser)
    {
        await _usersService.CreateAsync(newUser);

        return CreatedAtAction(nameof(Get), new { id = newUser.Id }, newUser);
    }

    [HttpPost("personae")]
    public async Task<IActionResult> Post(Persona newPersona)
    {
        await _personaeService.CreateAsync(newPersona);

        return CreatedAtAction(nameof(Get), new { id = newPersona.Id }, newPersona);
    }

    [HttpPost("devices")]
    public async Task<IActionResult> Post(Device newDevice)
    {
        await _devicesService.CreateAsync(newDevice);

        return CreatedAtAction(nameof(Get), new { id = newDevice.Id }, newDevice);
    }

}