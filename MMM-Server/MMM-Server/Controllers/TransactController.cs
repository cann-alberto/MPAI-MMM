using Microsoft.AspNetCore.Mvc;
using MMM_Server.Models;
using MMM_Server.Services;

namespace MMM_Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransactController : ControllerBase
{
    private readonly TransactService _transactService;

    public TransactController (TransactService transactService)
    {
        _transactService = transactService;
    }

    [HttpGet("transactions")]
    public async Task<List<Transaction>> Get() =>
        await _transactService.GetAsync();

    [HttpPost("transaction")]
    public async Task<IActionResult> Post(Transaction newTransaction)
    {
        await _transactService.CreateAsync(newTransaction);

        return CreatedAtAction(nameof(Get), new { id = newTransaction.TransactionID }, newTransaction);
    }


}
