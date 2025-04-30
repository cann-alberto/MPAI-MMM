using Microsoft.AspNetCore.Mvc;
using MMM_Server.Models;
using MMM_Server.Services;
using System.Text.Json;

namespace MMM_Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ConversionController : ControllerBase
{
    private readonly ItemService _itemService;
    private readonly BasicObjectService _basicObjectService;
    private readonly ObjectService _objectService;
    
    public ConversionController(ItemService itemService, BasicObjectService basicObjectService, ObjectService objectService)
    {
        _itemService = itemService;
        _basicObjectService = basicObjectService;
        _objectService = objectService;
    }


    [HttpPut("items/{itemId}")]
    public async Task<IActionResult> UpdateItemForItemId(string itemId, Item updatedItem)
    {
        try
        {
            await _itemService.UpdateAsync(itemId, updatedItem);

            return Ok($"Item with ID {updatedItem.ItemID} was successfully updated for {itemId}.");
        }
        catch (Exception ex)
        {
            return BadRequest($"An error occurred while updating the Item for {itemId}: {ex.Message}");
        }
    }


    [HttpPut("basic-objects/{basicObjectId}")]
    public async Task<IActionResult> UpdateItemForItemId(string basicObjectId, BasicObject updatedBasicObject)
    {
        try
        {
            await _basicObjectService.UpdateAsync(basicObjectId, updatedBasicObject);

            return Ok($"Basic Object with ID {updatedBasicObject.BasicObjectID} was successfully updated for {basicObjectId}.");
        }
        catch (Exception ex)
        {
            return BadRequest($"An error occurred while updating the Basic Object for {basicObjectId}: {ex.Message}");
        }
    }

    [HttpPut("objects/{objectId}")]
    public async Task<IActionResult> UpdateItemForItemId(string objectId, MObject updatedObject)
    {
        try
        {
            await _objectService.UpdateAsync(objectId, updatedObject);

            return Ok($"Object with ID {updatedObject.ObjectID} was successfully updated for {objectId}.");
        }
        catch (Exception ex)
        {
            return BadRequest($"An error occurred while updating the Object for {objectId}: {ex.Message}");
        }
    }


}
