using MMM_Server.Models;
using MMM_Server.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileSystemGlobbing.Internal;


namespace MMM_Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RegistrationController : ControllerBase
{

    private readonly PersonalProfileService _personalProfilesService;
    private readonly UserService _usersService;
    private readonly AccountService _accountsService;    

    public RegistrationController(
        PersonalProfileService profilesService, 
        UserService usersService,              
        AccountService accountsService, 
        ProcessActionService processActionService)
    {
        _personalProfilesService = profilesService;
        _usersService = usersService;        
        _accountsService = accountsService;        
    }

    [HttpGet("accounts/{humanId}")]
    public async Task<IActionResult> GetAccountByHumanId(string humanId)
    {
        try
        {
            // Call the service method to retrieve the account
            var account = await _accountsService.GetByHumanIdAsync(humanId);

            if (account == null)
            {
                // If no account is found, return a NotFound status
                return NotFound($"Account with HumanID {humanId} not found.");
            }

            // Return the account details
            return Ok(account);
        }
        catch (Exception ex)
        {
            // Handle any potential exceptions
            return BadRequest($"An error occurred while retrieving the account: {ex.Message}");
        }
    }

    [HttpGet("accounts")]
    public async Task<List<Account>> GetAccounts() =>
        await _accountsService.GetAsync();

    [HttpPost("accounts")]
    public async Task<IActionResult> Post(Account newAccount)
    {
        await _accountsService.CreateAsync(newAccount);

        return CreatedAtAction(nameof(GetAccounts), new { id = newAccount.AccountID }, newAccount);
    }
        

    [HttpPut("accounts/{accountId}")]
    public async Task<IActionResult> UpdateAccount(string accountId, Account updatedAccount)
    {
        try
        {
            // Call the AccountService to update the persona in the account
            await _accountsService.UpdateAsync(accountId, updatedAccount);

            // Return a success response
            return Ok($"Account with ID {updatedAccount.AccountID} was successfully updated");
        }
        catch (Exception ex)
        {
            // Return a bad request with the error message if something fails
            return BadRequest($"An error occurred while updating the account {accountId}: {ex.Message}");
        }
    }

    [HttpGet("avatars/{name}")]
    public IActionResult GetAvatar(string name, [FromQuery] string format = "glb")
    {
        // Ensure the name is safe to use in file paths
        if (string.IsNullOrWhiteSpace(name) || name.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
        {
            return BadRequest("Invalid avatar name.");
        }

        var avatarDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Resources", "Personae");
        var glbFilePath = Path.Combine(avatarDirectory, $"{name}.glb");
        var metadataFilePath = Path.Combine(avatarDirectory, $"{name}.json");
        var pngFilePath = Path.Combine(avatarDirectory, $"{name}.png");


        // If the requested format is "json", return the metadata
        if (format.ToLower() == "json")
        {
            if (System.IO.File.Exists(metadataFilePath))
            {
                var fileBytes = System.IO.File.ReadAllBytes(metadataFilePath);
                return File(fileBytes, "application/json", $"{name}.json");
            }
            else
            {
                return NotFound($"Metadata file for avatar '{name}.json' not found.");
            }
        }
        // If the requested format is "glb", return the 3D model
        else if (format.ToLower() == "glb")
        {
            if (System.IO.File.Exists(glbFilePath))
            {
                var fileBytes = System.IO.File.ReadAllBytes(glbFilePath);
                return File(fileBytes, "model/gltf-binary", $"{name}.glb");
            }
            else
            {
                return NotFound($"Avatar file '{name}.glb' not found.");
            }
        }
        // If the requested format is "png", return the preview image of the model
        else if (format.ToLower() == "png")
        {
            if (System.IO.File.Exists(pngFilePath))
            {
                var fileBytes = System.IO.File.ReadAllBytes(pngFilePath);
                return File(fileBytes, "image/png", $"{name}.png");
            }
            else
            {
                return NotFound($"Image file '{name}.png' not found.");
            }
        }

        else
        {
            return BadRequest("Invalid format specified. Use 'json' or 'glb'.");
        }
    }

    [HttpGet("profiles")]
    public async Task<List<PersonalProfile>> GetProfiles() =>
        await _personalProfilesService.GetAsync();

    [HttpPost("profiles")]
    public async Task<IActionResult> Post(PersonalProfile newPersonalProfile)
    {
        // Insert the new profile in the DB
        await _personalProfilesService.CreateAsync(newPersonalProfile);
                
        return CreatedAtAction(nameof(GetProfiles), new { id = newPersonalProfile.PersonalProfileID }, newPersonalProfile);
    }

    [HttpGet("users")]
    public async Task<List<User>> GetUsers() =>
    await _usersService.GetAsync();

    [HttpPost ("users")]
    public async Task<IActionResult> Post(User newUser)
    {
        await _usersService.CreateAsync(newUser);

        return CreatedAtAction(nameof(GetUsers), new { id = newUser.UserID }, newUser);
    }
       

}