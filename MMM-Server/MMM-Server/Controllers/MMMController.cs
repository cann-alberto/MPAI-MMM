using Microsoft.AspNetCore.Mvc;
using MMM_Server.Models;
using MMM_Server.Services;

[ApiController]
[Route("api/[controller]")]
public class MMMController : ControllerBase
{
    private readonly AccountService _accountService;
    private readonly ItemService _itemService;

    public MMMController(AccountService accountsService, ItemService itemService)
    {
        _accountService = accountsService;
        _itemService = itemService;
    }

    #region Account

    [HttpGet("Accounts")]
    public async Task<List<Account>> Get() =>
        await _accountService.GetAsync();

    [HttpGet("Accounts/{id}")]
    public async Task<ActionResult<Account>> Get(string id)
    {
        var account = await _accountService.GetAsync(id);
        if (account is null)
        {
            return NotFound($"Account with ID {id} not found.");
        }
        return account;
    }

    [HttpPost("Accounts")]
    public async Task<IActionResult> Post(Account newAccount)
    {
        await _accountService.CreateAsync(newAccount);
        // nameof(Get) refers to the Get(string id) method above
        return CreatedAtAction(nameof(Get), new { id = newAccount.AccountID }, newAccount);
    }

    [HttpPut("Accounts/{id}")]
    public async Task<IActionResult> Update(string id, Account updatedAccount)
    {
        try
        {
            // Ensure the ID in the object matches the URL parameter
            updatedAccount.AccountID = id;
            await _accountService.UpdateAsync(id, updatedAccount);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpDelete("Accounts/{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        try
        {
            // FIXED: Use the RemoveAsync method from the new base service
            await _accountService.RemoveAsync(id);
            return Ok($"Account with ID {id} was successfully deleted.");
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    #endregion


    
    #region Item

    [HttpGet("Items")]
    public async Task<List<Item>> GetItems() =>
        await _itemService.GetAsync();

    [HttpGet("Items/{id}")]
    public async Task<ActionResult<Item>> GetItem(string id)
    {
        var item = await _itemService.GetAsync(id);
        return item is null ? NotFound($"Item {id} not found.") : item;
    }

    [HttpPost("Items")]
    public async Task<IActionResult> PostItem(Item newItem)
    {
        // ASP.NET Core automatically runs the IValidatableObject.Validate logic here
        await _itemService.CreateAsync(newItem);
        return CreatedAtAction(nameof(GetItem), new { id = newItem.ItemID }, newItem);
    }

    [HttpPut("Items/{id}")]
    public async Task<IActionResult> UpdateItem(string id, Item updatedItem)
    {
        try
        {
            updatedItem.ItemID = id;
            await _itemService.UpdateAsync(id, updatedItem);
            return NoContent();
        }
        catch (KeyNotFoundException ex) { return NotFound(ex.Message); }
    }

    [HttpDelete("Items/{id}")]
    public async Task<IActionResult> DeleteItem(string id)
    {
        try
        {
            await _itemService.RemoveAsync(id);
            return Ok($"Item {id} deleted.");
        }
        catch (KeyNotFoundException ex) { return NotFound(ex.Message); }
    }

    #endregion
}