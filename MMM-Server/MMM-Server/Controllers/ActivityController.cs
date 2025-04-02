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


    [HttpGet("users")]
    public async Task<List<User>> Get() =>
        await _usersService.GetAsync();


    [HttpGet("user/humanid/{humanId}")]
    public async Task<IActionResult> GetUserByHumanId(string humanId)
    {
        try
        {
            // Call the service method to retrieve the account
            var user = await _usersService.GetUserByHumanIdAsync(humanId);

            if (user == null)
            {
                // If no account is found, return a NotFound status
                return NotFound($"User with HumanID {humanId} not found.");
            }

            // Return the account details
            return Ok(user);
        }
        catch (Exception ex)
        {
            // Handle any potential exceptions
            return BadRequest($"An error occurred while retrieving the account: {ex.Message}");
        }
    }


    [HttpPut("users/{userId}/comInfo")]
    public async Task<IActionResult> UpdateAccount(string userId, User updatedUser)
    {
        try
        {
            // Call the AccountService to update the persona in the account
            await _usersService.UpdateAsync(userId, updatedUser);

            // Return a success response
            return Ok($"Account with ID {updatedUser.UserID} was successfully updated");
        }
        catch (Exception ex)
        {
            // Return a bad request with the error message if something fails
            return BadRequest($"An error occurred while updating the user {userId}: {ex.Message}");
        }
    }



}








