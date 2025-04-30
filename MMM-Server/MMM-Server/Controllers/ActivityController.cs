using Microsoft.AspNetCore.Mvc;
using MMM_Server.Models;
using MMM_Server.Services;

namespace MMM_Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ActivityController: ControllerBase
{
    private readonly UserService _usersService;
    private readonly ProcessActionService _actionsService;


    public ActivityController(UserService usersService, ProcessActionService actionService)
    {
        _usersService = usersService;
        _actionsService = actionService;
    }

    [HttpGet("process-actions")]
    public async Task<List<ProcessAction>> Get() =>
       await _actionsService.GetAsync();

    
    [HttpPost("process-actions")]
    public async Task<IActionResult> Post(ProcessAction newProcessAction)
    {
        await _actionsService.CreateAsync(newProcessAction);

        return CreatedAtAction(nameof(Get), new { id = newProcessAction.ProcessActionID }, newProcessAction);
    }

    [HttpPut("process-actions/{processActionId}")]
    public async Task<IActionResult> UpdateRightForRightId(string processActionId, ProcessAction updatedProcessAction)
    {
        try
        {            
            await _actionsService.UpdateAsync(processActionId, updatedProcessAction);
            
            return Ok($"Process Action with ID {updatedProcessAction.ProcessActionID} was successfully updated for right {processActionId}.");
        }
        catch (Exception ex)
        {            
            return BadRequest($"An error occurred while updating the process action for {processActionId}: {ex.Message}");
        }
    }

    // Delete an existing right by rightId
    [HttpDelete("process-action/{processActionId}")]
    public async Task<IActionResult> DeleteRight(string processActionId)
    {
        try
        {
            await _actionsService.DeleteAsync(processActionId);
            return Ok($"Process Action with ID {processActionId} was successfully deleted.");
        }
        catch (Exception ex)
        {
            return NotFound($"An error occurred while deleting the process action with ID {processActionId}: {ex.Message}");
        }
    }



    [HttpGet("users")]
    public async Task<List<User>> GetUsers() =>
        await _usersService.GetAsync();


    [HttpGet("users/humanid/{humanId}")]
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








