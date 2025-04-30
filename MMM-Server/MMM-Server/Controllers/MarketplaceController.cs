using Microsoft.AspNetCore.Mvc;
using MMM_Server.Models;
using MMM_Server.Services;

namespace MMM_Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MarketplaceController:ControllerBase
{
    private readonly AssetService _assetService;

    public MarketplaceController(AssetService assetService)
    {
        _assetService = assetService;
    }

    [HttpGet("assets")]
    public async Task<List<Asset>> GetAssets() =>
        await _assetService.GetAsync();

    [HttpPost("assets")]
    public async Task<IActionResult> Post(Asset newAsset)
    {
        await _assetService.CreateAsync(newAsset);

        return CreatedAtAction(nameof(GetAssets), new { id = newAsset.AssetID}, newAsset);
    }

    [HttpDelete("assets/{id}")]
    public async Task<IActionResult> DeleteAuthentication(string id)
    {
        try
        {
            await _assetService.DeleteAsync(id);
            return Ok($"Asset with ID {id} was successfully deleted.");
        }
        catch (Exception ex)
        {
            return NotFound($"An error occurred while deleting the asset with ID {id}: {ex.Message}");
        }
    }

    // Update an existing wallet by walletId
    [HttpPut("assets/{assetId}")]
    public async Task<IActionResult> UpdateAssetForAssetId(string assetId, Asset updatedAsset)
    {
        try
        {
            // Call the AccountService to update the persona in the account
            await _assetService.UpdateAsync(assetId, updatedAsset);

            // Return a success response
            return Ok($"Asset with ID {updatedAsset.AssetID} was successfully updated for {assetId}.");
        }
        catch (Exception ex)
        {
            // Return a bad request with the error message if something fails
            return BadRequest($"An error occurred while updating the asset for {assetId}: {ex.Message}");
        }
    }
}

