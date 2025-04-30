using Microsoft.AspNetCore.Mvc;
using MMM_Server.Models;
using MMM_Server.Services;

namespace MMM_Server.Controllers;

[ApiController]
[Route("api/[controller]")]

public class AuthenticationController:ControllerBase
{
    private readonly AuthenticationService _authenticationService;

    public AuthenticationController(AuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;        
    }

    [HttpGet("authentications")]
    public async Task<List<Authentication>> GetAuthentications() =>
        await _authenticationService.GetAsync();
         
    [HttpPost("authentications")]
    public async Task<IActionResult> Post(Authentication newAuthentication)
    {
        await _authenticationService.CreateAsync(newAuthentication);

        return CreatedAtAction(nameof(GetAuthentications), new { id = newAuthentication.AuthenticationID}, newAuthentication);
    }
    
    [HttpDelete("authentications/{id}")]
    public async Task<IActionResult> DeleteAuthentication(string id)
    {
        try
        {
            await _authenticationService.DeleteAsync(id);
            return Ok($"Authentication with ID {id} was successfully deleted.");
        }
        catch (Exception ex)
        {
            return NotFound($"An error occurred while deleting the authentication with ID {id}: {ex.Message}");
        }
    }

}
