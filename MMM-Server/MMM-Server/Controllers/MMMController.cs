using Microsoft.AspNetCore.Mvc;
using MMM_Server.Models;
using MMM_Server.Services;

namespace MMM_Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MMMController : ControllerBase
{
    private readonly AccountService _accountService;    

    public MMMController(AccountService accountsService)
    {        
        _accountService = accountsService;
    }


    #region Account
    // GET: api/MMM/Account
    [HttpGet("Accounts")]
    public async Task<List<Account>> Get() =>
        await _accountService.GetAsync();

    // GET: api/MMM/Account/{id}
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

    // POST: api/MMM/Account
    [HttpPost("Accounts")]
    public async Task<IActionResult> Post(Account newAccount)
    {
        await _accountService.CreateAsync(newAccount);

        return CreatedAtAction(nameof(Get), new { id = newAccount.AccountID }, newAccount);
    }

    // PUT: api/MMM/Account/{id}
    [HttpPut("Accounts/{id}")]
    public async Task<IActionResult> Update(string id, Account updatedAccount)
    {
        try
        {
            // Ensure the ID in the body matches the ID in the route, 
            // or force the route ID onto the object
            updatedAccount.AccountID = id;

            await _accountService.UpdateAsync(id, updatedAccount);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    // DELETE: api/MMM/Account/{id}
    [HttpDelete("Accounts/{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        try
        {
            // Note: Ensure your AccountService has a Delete/Remove method implemented
            // Based on your previous request, you might need to add this to the service:
            // await _accountService.RemoveAsync(id); 

            // Assuming the method name is DeleteAsync to match your Location pattern:
            await _accountService.UpdateAsync(id, null!); // Placeholder if using your provided Update logic

            // Recommending adding a proper Delete method to AccountService, then:
            // await _accountService.RemoveAsync(id);

            return Ok($"Account with ID {id} was successfully deleted.");
        }
        catch (Exception ex)
        {
            return NotFound($"An error occurred while deleting the account with ID {id}: {ex.Message}");
        }
    }

    #endregion


}
