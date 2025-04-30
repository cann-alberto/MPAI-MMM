using Microsoft.AspNetCore.Mvc;
using MMM_Server.Models;
using MMM_Server.Services;


namespace MMM_Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransactionController : ControllerBase
{
    private readonly TransactService _transactService;
    private readonly WalletService _walletService;    

    public TransactionController (TransactService transactService, WalletService walletService)
    {        
        _transactService = transactService;
        _walletService= walletService;
    }

    // Get all the transactions
    [HttpGet("transactions")]
    public async Task<List<Transaction>> GetTrasactions() =>
        await _transactService.GetAsync();
    
    // Create a new transaction
    [HttpPost("transactions")]
    public async Task<IActionResult> Post(Transaction newTransaction)
    {
        await _transactService.CreateAsync(newTransaction);

        return CreatedAtAction(nameof(GetTrasactions), new { id = newTransaction.TransactionID }, newTransaction);
    }

    // Get the all the wallets
    [HttpGet("wallets")]
    public async Task<List<Wallet>> GetWallets() =>
        await _walletService.GetAsync();

    // Get wallet by WalletID
    [HttpGet("wallets/{walletId}")]
    public async Task<IActionResult> GetWalletById(string walletId)
    {
        var wallet = await _walletService.GetByIdAsync(walletId);
        if (wallet == null)
            return NotFound($"Wallet with ID {walletId} not found.");

        return Ok(wallet);
    }
    

    // Create a new wallet
    [HttpPost("wallets")]
    public async Task<IActionResult> Post(Wallet newWallet)
    {
        await _walletService.CreateAsync(newWallet);

        return CreatedAtAction(nameof(GetWallets), new { id = newWallet.WalletID }, newWallet);
    }

    // Update an existing wallet by walletId
    [HttpPut("wallets/{walletId}")]
    public async Task<IActionResult> UpdateWalletForWalletId(string walletId, Wallet updatedWallet)
    {
        try
        {
            // Call the AccountService to update the persona in the account
            await _walletService.UpdateAsync(walletId, updatedWallet);

            // Return a success response
            return Ok($"Wallet with ID {updatedWallet.WalletID} was successfully updated for account {walletId}.");
        }
        catch (Exception ex)
        {
            // Return a bad request with the error message if something fails
            return BadRequest($"An error occurred while updating the wallet for {walletId}: {ex.Message}");
        }
    }
}
