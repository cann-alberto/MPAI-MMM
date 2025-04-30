using Microsoft.AspNetCore.Mvc;
using MMM_Server.Models;
using MMM_Server.Services;

namespace MMM_Server.Controllers;

[ApiController]
[Route("api/[controller]")]

public class DiscoveryController : ControllerBase
{
    private readonly DiscoveryService _discoveryService;

    public DiscoveryController(DiscoveryService discoveryService)
    {
        _discoveryService = discoveryService;   
    }

    [HttpGet("basic-discoveries")]
    public async Task<List<BasicDiscovery>> GetBasicDiscoveries() =>
        await _discoveryService.GetAsync();

    [HttpPost("basic-discoveries")]
    public async Task<IActionResult> Post(BasicDiscovery newBasicDiscovery)
    {
        await _discoveryService.CreateAsync(newBasicDiscovery);

        return CreatedAtAction(nameof(GetBasicDiscoveries), new { id = newBasicDiscovery.BasicDiscoveryID}, newBasicDiscovery);
    }

    [HttpDelete("basic-discoveries/{id}")]
    public async Task<IActionResult> DeleteAuthentication(string id)
    {
        try
        {
            await _discoveryService.DeleteAsync(id);
            return Ok($"Basic discovery with ID {id} was successfully deleted.");
        }
        catch (Exception ex)
        {
            return NotFound($"An error occurred while deleting the basic discovery with ID {id}: {ex.Message}");
        }
    }

    [HttpGet("basic-discoveries/{id}")]
    public async Task<IActionResult> GetItemIdsAndProcesses(string id)
    {
        var discovery = await _discoveryService.GetAsync(id);

        if (discovery == null || discovery.BasicDiscoveryData?.DiscoveryResponse == null)
        {
            return NotFound($"No BasicDiscovery or DiscoveryResponse found with ID {id}.");
        }

        var itemIds = discovery.BasicDiscoveryData.DiscoveryResponse.Items?
            .Where(i => !string.IsNullOrEmpty(i.ItemID))
            .Select(i => i.ItemID)
            .ToList() ?? new List<string>();

        var processes = discovery.BasicDiscoveryData.DiscoveryResponse.Processes ?? new List<string>();

        return Ok(new
        {
            ItemIDs = itemIds,
            Processes = processes
        });
    }
}