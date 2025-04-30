using Microsoft.AspNetCore.Mvc;
using MMM_Server.Models;
using MMM_Server.Services;
using System.Text.Json;


namespace MMM_Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LocationController : ControllerBase
{
    private readonly BasicMLocationService _basicMLocationService;
    private readonly MLocationService _mLocationService;

    public LocationController(BasicMLocationService basicMLocationService, MLocationService mLocationService)
    {
        _basicMLocationService = basicMLocationService;
        _mLocationService = mLocationService;
    }

    #region basic MLocation
    [HttpGet("basic-mlocations")]
    public async Task<List<BasicMLocation>> GetBasicMLocations() =>
        await _basicMLocationService.GetAsync();
    
    [HttpPost("basic-mlocations")]
    public async Task<IActionResult> Post(BasicMLocation newBasicMLocation)
    {
        await _basicMLocationService.CreateAsync(newBasicMLocation);

        return CreatedAtAction(nameof(GetBasicMLocations), new { id = newBasicMLocation.BasicMLocationID }, newBasicMLocation);
    }

    // Delete an existing basic mLocation by basicMLocationId
    [HttpDelete("basic-mlocations/{basicMLocationId}")]
    public async Task<IActionResult> DeleteBasicObject(string basicMLocationId)
    {
        try
        {
            await _basicMLocationService.DeleteAsync(basicMLocationId);
            return Ok($"Basic MLocatin with ID {basicMLocationId} was successfully deleted.");
        }
        catch (Exception ex)
        {
            return NotFound($"An error occurred while deleting the basic MLocation with ID {basicMLocationId}: {ex.Message}");
        }
    }
    #endregion

    #region MLocation
    [HttpGet("mlocations")]
    public async Task<List<MLocation>> GetMLocations() =>
        await _mLocationService.GetAsync();

    [HttpPost("mlocations")]
    public async Task<IActionResult> Post(MLocation newMLocation)
    {
        await _mLocationService.CreateAsync(newMLocation);

        return CreatedAtAction(nameof(GetMLocations), new { id = newMLocation.MLocationID}, newMLocation);
    }

    // Delete an existing basic mLocation by basicMLocationId
    [HttpDelete("mlocations/{mLocationId}")]
    public async Task<IActionResult> DeleteObject(string mLocationId)
    {
        try
        {
            await _mLocationService.DeleteAsync(mLocationId);
            return Ok($"MLocatin with ID {mLocationId} was successfully deleted.");
        }
        catch (Exception ex)
        {
            return NotFound($"An error occurred while deleting the MLocation with ID {mLocationId}: {ex.Message}");
        }
    }
    #endregion

}





