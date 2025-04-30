using Microsoft.AspNetCore.Mvc;
using MMM_Server.Models;
using MMM_Server.Services;
using System.Text.Json;

namespace MMM_Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorController : ControllerBase
{
    private readonly ItemService _itemService;
    private readonly BasicObjectService _basicObjectService;
    private readonly ObjectService _objectService;

    public AuthorController(ItemService itemService, BasicObjectService basicObjectService, ObjectService objectService) 
    {
        _itemService = itemService;
        _basicObjectService = basicObjectService;
        _objectService = objectService;
    }
   

    #region item
    // Get all the basic objects
    [HttpGet("items")]
    public async Task<List<Item>> GetItems() =>
        await _itemService.GetAsync();


    [HttpPost("items")]
    public async Task<IActionResult> Post([FromBody] JsonElement jsonBody, [FromQuery] string format = "item")
    {
        try
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };


            if (format.ToLower() == "item")
            {
                Item newItem = JsonSerializer.Deserialize<Item>(jsonBody.GetRawText(), options)!;

                await _itemService.CreateAsync(newItem);
                return CreatedAtAction(nameof(GetItems), new { id = newItem.ItemID }, newItem);
            }
            if (format.ToLower() == "basic-object")
            {
                BasicObject newItem = JsonSerializer.Deserialize<BasicObject>(jsonBody.GetRawText(), options)!;
                await _basicObjectService.CreateAsync(newItem);

                return CreatedAtAction(nameof(GetBasicObjects), new { id = newItem.BasicObjectID }, newItem);
            }
            if (format.ToLower() == "object")
            {
                MObject newItem = JsonSerializer.Deserialize<MObject>(jsonBody.GetRawText(), options)!;
                await _objectService.CreateAsync(newItem);

                return CreatedAtAction(nameof(GetBasicObjects), new { id = newItem.ObjectID }, newItem);
            }
            return BadRequest("Unsupported format");
        }
        catch (JsonException ex)
        {
            return BadRequest($"Invalid JSON: {ex.Message}");
        }
    }


    [HttpDelete("items/{id}")]
    public async Task<IActionResult> Delete(string id, [FromQuery] string format = "item")
    {
        if (format.ToLower() == "item")
        {
            var existingItem = await _itemService.GetAsync(id);
            if (existingItem == null)
                return NotFound($"Item with ID {id} not found.");

            await _itemService.DeleteAsync(id);
            return Ok($"Item with ID {id} was successfully deleted.");
        }

        if (format.ToLower() == "basic-object")
        {
            var existingBasicObject = await _basicObjectService.GetAsync(id);
            if (existingBasicObject == null)
                return NotFound($"BasicObject with ID {id} not found.");

            await _basicObjectService.DeleteAsync(id);
            return Ok($"Basic Object with ID {id} was successfully deleted.");
        }
        
        if (format.ToLower() == "object")
        {
            var existingObject = await _objectService.GetAsync(id);
            if (existingObject == null)
                return NotFound($"Object with ID {id} not found.");

            await _objectService.DeleteAsync(id);
            return Ok($"Object with ID {id} was successfully deleted.");
        }

        return BadRequest("Unsupported format");
    }

    #endregion

    #region Basic Object
    // Get all the basic objects
    [HttpGet("basic-objects")]
    public async Task<List<BasicObject>> GetBasicObjects() =>
        await _basicObjectService.GetAsync();

    // Create a new basic object
    [HttpPost("basic-objects")]
    public async Task<IActionResult> Post(BasicObject newBasicObject)
    {
        await _basicObjectService.CreateAsync(newBasicObject);

        return CreatedAtAction(nameof(GetBasicObjects), new { id = newBasicObject.BasicObjectID }, newBasicObject);
    }

    // Delete an existing basic object by basicObjectId
    [HttpDelete("basic-objects/{basicObjectId}")]
    public async Task<IActionResult> DeleteBasicObject(string basicObjectId)
    {
        try
        {
            await _basicObjectService.DeleteAsync(basicObjectId);
            return Ok($"Basic object with ID {basicObjectId} was successfully deleted.");
        }
        catch (Exception ex)
        {
            return NotFound($"An error occurred while deleting the basic object with ID {basicObjectId}: {ex.Message}");
        }
    }
    #endregion

    #region Object
    // Get all the objects
    [HttpGet("objects")]
    public async Task<List<MObject>> GetObjects() =>
        await _objectService.GetAsync();

    // Create a new object
    [HttpPost("objects")]
    public async Task<IActionResult> Post(MObject newObject)
    {
        await _objectService.CreateAsync(newObject);

        return CreatedAtAction(nameof(GetObjects), new { id = newObject.ObjectID }, newObject);
    }

    // Delete an existing object by objectId
    [HttpDelete("objects/{objectId}")]
    public async Task<IActionResult> DeleteObject(string objectId)
    {
        try
        {
            await _objectService.DeleteAsync(objectId);
            return Ok($"Object with ID {objectId} was successfully deleted.");
        }
        catch (Exception ex)
        {
            return NotFound($"An error occurred while deleting the object with ID {objectId}: {ex.Message}");
        }
    }
    #endregion
}