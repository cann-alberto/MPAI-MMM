using Microsoft.AspNetCore.Mvc;
using MMM_Server.Models;
using MMM_Server.Services;
namespace MMM_Server.Controllers;

[ApiController]
[Route("api/[controller]")]

public class CommunicationController : ControllerBase
{
    private readonly MessageService _messageService;

    public CommunicationController(MessageService messageService)
    {
        _messageService = messageService;
    }

    [HttpGet("messages")]
    public async Task<List<Message>> Get() =>
        await _messageService.GetAsync();

    [HttpPost("messages")]
    public async Task<IActionResult> Post(Message newMessage)
    {
        await _messageService.CreateAsync(newMessage);

        return CreatedAtAction(nameof(Get), new { id = newMessage.MessageID }, newMessage);
    }


}
