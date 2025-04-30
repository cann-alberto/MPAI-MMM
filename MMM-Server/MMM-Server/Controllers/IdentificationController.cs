using Microsoft.AspNetCore.Mvc;
using MMM_Server.Services;


namespace MMM_Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IdentificationController : ControllerBase
{
    private readonly ItemService _itemService;
    private readonly BasicObjectService _basicObjectService;
    private readonly ObjectService _objectService;


    public IdentificationController(ItemService itemService, BasicObjectService basicObjectService, ObjectService objectService)
    {
        _itemService = itemService;
        _basicObjectService = basicObjectService;
        _objectService = objectService;
    }        

    // Create an item
    //[HttpPost("-items")]
    //public async Task<IActionResult> PostItem(Item newItem)
    //{
    //    await _itemService.CreateAsync(newItem);

    //    return CreatedAtAction(nameof(GetItems), new { id = newItem.ItemID }, newItem);
    //}      
}