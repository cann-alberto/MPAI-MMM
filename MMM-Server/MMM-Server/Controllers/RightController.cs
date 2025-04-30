using Microsoft.AspNetCore.Mvc;
using MMM_Server.Models;
using MMM_Server.Services;


namespace MMM_Server.Controllers;


[ApiController]
[Route("api/[controller]")]
public class RightController : ControllerBase
{
    private readonly RightService _rigthService;
    private readonly AccountService _accountService;
    private readonly BasicObjectService _basicObjectService;
    private readonly ObjectService _objectService;
    private readonly BasicMLocationService _basicMLocationService;
    private readonly MLocationService _mLocationService;


    public RightController(RightService rigthService, AccountService accountService, 
        BasicObjectService basicObjectService, ObjectService objectService,
        BasicMLocationService basicMLocationService, MLocationService mLocationService)
    {
        _rigthService = rigthService;
        _accountService = accountService;
        _basicObjectService = basicObjectService;
        _objectService = objectService;
        _basicMLocationService = basicMLocationService;
        _mLocationService = mLocationService;
    }

    // Get all the rigths
    [HttpGet("rights")]
    public async Task<List<Right>> GetRights() =>
        await _rigthService.GetAsync();

    // Create a new right
    [HttpPost("rights")]
    public async Task<IActionResult> Post(Right newRight)
    {
        await _rigthService.CreateAsync(newRight);

        return CreatedAtAction(nameof(GetRights), new { id = newRight.RightID }, newRight);
    }

    // Update an existing right by rightId
    [HttpPut("rights/{rightId}")]
    public async Task<IActionResult> UpdateRightForRightId(string rightId, Right updatedRight)
    {
        try
        {
            // Call the AccountService to update the persona in the account
            await _rigthService.UpdateAsync(rightId, updatedRight);

            // Return a success response
            return Ok($"Right with ID {updatedRight.RightID} was successfully updated for right {rightId}.");
        }
        catch (Exception ex)
        {
            // Return a bad request with the error message if something fails
            return BadRequest($"An error occurred while updating the right for {rightId}: {ex.Message}");
        }
    }

    // Delete an existing right by rightId
    [HttpDelete("rights/{rightId}")]
    public async Task<IActionResult> DeleteRight(string rightId)
    {
        try
        {
            await _rigthService.DeleteAsync(rightId);
            return Ok($"Right with ID {rightId} was successfully deleted.");
        }
        catch (Exception ex)
        {
            return NotFound($"An error occurred while deleting the right with ID {rightId}: {ex.Message}");
        }
    }

    #region account rights
    // Get all the rights for a specific account by accountId
    [HttpGet("accounts/{accountId}/{userId}/rights")]
    public async Task<IActionResult> GetRightsForAccount(string accountId, string userId)
    {
        try
        {
            var rights = await _accountService.GetRightsForAccountAsync(accountId, userId);
            if (rights == null || rights.Count == 0)
            {
                return NotFound($"No rights found for account {accountId}.");
            }

            return Ok(rights);
        }
        catch (Exception ex)
        {
            return BadRequest($"An error occurred while retrieving rights for account {accountId}: {ex.Message}");
        }
    }

    // Add right to an account selected by AccountId
    [HttpPut("accounts/{accountId}/{userId}/rights")]
    public async Task<IActionResult> AddRightForAccount(string accountId, string userId, string rightId)
    {
        try
        {
            // Call the AccountService to update the persona in the account
            await _accountService.AddRightToAccountAsync(accountId, userId, rightId);

            // Return a success response
            return Ok($"Right with ID {rightId} was successfully updated for account {accountId}.");
        }
        catch (Exception ex)
        {
            // Return a bad request with the error message if something fails
            return BadRequest($"An error occurred while updating the right for account {accountId}: {ex.Message}");
        }
    }

    // Remove an existing right from an Account selected by AccountId
    [HttpDelete("accounts/{accountId}/{userId}/rights/{rightId}")]
    public async Task<IActionResult> DeleteRightForAccountId(string accountId, string userId, string rightId)
    {
        try
        {
            await _accountService.DeleteRightFromAccountAsync(accountId, userId, rightId);
            return Ok($"Right with ID {rightId} was successfully deleted.");
        }
        catch (Exception ex)
        {
            return NotFound($"An error occurred while deleting the right with ID {rightId}: {ex.Message}");
        }
    }
    #endregion

    #region basic-object rights
    // Get all the rights for a specific basic object by basicObjectId
    [HttpGet("basic-objects/{basicObjectId}/rights")]
    public async Task<IActionResult> GetRightsForBasicObject(string basicObjectId)
    {
        try
        {
            var rights = await _basicObjectService.GetRightsForBasicObjectAsync(basicObjectId);
            if (rights == null || rights.Count == 0)
            {
                return NotFound($"No rights found for basic object {basicObjectId}.");
            }

            return Ok(rights);
        }
        catch (Exception ex)
        {
            return BadRequest($"An error occurred while retrieving rights for basic object {basicObjectId}: {ex.Message}");
        }
    }

    // Add right to a basic object selected by BasicObjectId
    [HttpPut("basic-objects/{basicObjectId}/rights")]
    public async Task<IActionResult> AddRightForBasicObject(string basicObjectId, string rightId)
    {
        try
        {
            await _basicObjectService.AddRightToBasicObjectAsync(basicObjectId, rightId);

            return Ok($"Right with ID {rightId} was successfully updated for basic object {basicObjectId}.");
        }
        catch (Exception ex)
        {
            return BadRequest($"An error occurred while updating the right for basic object {basicObjectId}: {ex.Message}");
        }
    }

    // Remove an existing right from a basic object selected by BasicObjectId
    [HttpDelete("basic-objects/{basicObjectId}/rights/{rightId}")]
    public async Task<IActionResult> DeleteRightForBasicObject(string basicObjectId, string rightId)
    {
        try
        {
            await _basicObjectService.DeleteRightForBasicObjectAsync(basicObjectId, rightId);
            return Ok($"Right with ID {rightId} was successfully deleted.");
        }
        catch (Exception ex)
        {
            return NotFound($"An error occurred while deleting the right with ID {rightId}: {ex.Message}");
        }
    }
    #endregion

    #region object rights
    // Get all the rights for a specific object by objectId
    [HttpGet("objects/{objectId}/rights")]
    public async Task<IActionResult> GetRightsForObject(string objectId)
    {
        try
        {
            var rights = await _objectService.GetRightsForObjectAsync(objectId);
            if (rights == null || rights.Count == 0)
            {
                return NotFound($"No rights found for object {objectId}.");
            }

            return Ok(rights);
        }
        catch (Exception ex)
        {
            return BadRequest($"An error occurred while retrieving rights for object {objectId}: {ex.Message}");
        }
    }

    // Add right to a specific object selected by objectId
    [HttpPut("objects/{objectId}/rights")]
    public async Task<IActionResult> AddRightForObject(string objectId, string rightId)
    {
        try
        {            
            await _objectService.AddRightToObjectAsync(objectId, rightId);

            return Ok($"Right with ID {rightId} was successfully updated for object {objectId}.");
        }
        catch (Exception ex)
        {
            return BadRequest($"An error occurred while updating the right for object {objectId}: {ex.Message}");
        }
    }

    // Remove an existing right from a basic object selected by BasicObjectId
    [HttpDelete("objects/{ObjectId}/rights/{rightId}")]
    public async Task<IActionResult> DeleteRightForObject(string objectId, string rightId)
    {
        try
        {
            await _objectService.DeleteRightToObjectAsync(objectId, rightId);              
            return Ok($"Right with ID {rightId} was successfully deleted.");
        }
        catch (Exception ex)
        {
            return NotFound($"An error occurred while deleting the right with ID {rightId}: {ex.Message}");
        }
    }

    #endregion

    #region basic-mLocation rights
    [HttpGet("basic-mLocations/{mLocationId}/rights")]
    public async Task<IActionResult> GetRightsForBasicMLocation(string mLocationId)
    {
        try
        {
            var rights = await _basicMLocationService.GetRightsForBasicMLocationAsync(mLocationId);
            if (rights == null || rights.Count == 0)
            {
                return NotFound($"No rights found for basic MLocation {mLocationId}.");
            }

            return Ok(rights);
        }
        catch (Exception ex)
        {
            return BadRequest($"An error occurred while retrieving rights for basic MLocation {mLocationId}: {ex.Message}");
        }
    }
    
    [HttpPut("basic-mLocations/{mLocationId}/rights")]
    public async Task<IActionResult> AddRightForBasicMLocation(string mLocationId, string rightId)
    {
        try
        {
            await _basicMLocationService.AddRightToBasicMLocationAsync(mLocationId, rightId);

            return Ok($"Right with ID {rightId} was successfully updated for basic MLocation {mLocationId}.");
        }
        catch (Exception ex)
        {
            return BadRequest($"An error occurred while updating the right for basic MLocation {mLocationId}: {ex.Message}");
        }
    }
    
    [HttpDelete("basic-mLocations/{mLocationId}/rights/{rightId}")]
    public async Task<IActionResult> DeleteRightForBasicMLocation(string mLocationId, string rightId)
    {
        try
        {
            await _basicMLocationService.DeleteRightForBasicMLocationAsync(mLocationId, rightId);
            return Ok($"Right with ID {rightId} was successfully deleted.");
        }
        catch (Exception ex)
        {
            return NotFound($"An error occurred while deleting the right with ID {rightId}: {ex.Message}");
        }
    }

    #endregion

    #region mLocation rights
    [HttpGet("mLocations/{mLocationId}/rights")]
    public async Task<IActionResult> GetRightsForMLocation(string mLocationId)
    {
        try
        {
            var rights = await _mLocationService.GetRightsForMLocationAsync(mLocationId);
            if (rights == null || rights.Count == 0)
            {
                return NotFound($"No rights found for MLocation {mLocationId}.");
            }

            return Ok(rights);
        }
        catch (Exception ex)
        {
            return BadRequest($"An error occurred while retrieving rights for MLocation {mLocationId}: {ex.Message}");
        }
    }
    
    [HttpPut("mLocations/{mLocationId}/rights")]
    public async Task<IActionResult> AddRightForMLocation(string mLocationId, string rightId)
    {
        try
        {            
            await _mLocationService.AddRightToMLocationAsync(mLocationId, rightId);
         
            return Ok($"Right with ID {rightId} was successfully updated for MLocation {mLocationId}.");
        }
        catch (Exception ex)
        {            
            return BadRequest($"An error occurred while updating the right for MLocation {mLocationId}: {ex.Message}");
        }
    }
    
    [HttpDelete("mLocations/{mLocationId}/rights/{rightId}")]
    public async Task<IActionResult> DeleteRightForMLocation(string mLocationId, string rightId)
    {
        try
        {
            await _mLocationService.DeleteRightForMLocationAsync(mLocationId, rightId);
            return Ok($"Right with ID {rightId} was successfully deleted.");
        }
        catch (Exception ex)
        {
            return NotFound($"An error occurred while deleting the right with ID {rightId}: {ex.Message}");
        }
    }
    #endregion


}