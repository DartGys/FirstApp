using Microsoft.AspNetCore.Mvc;
using TaskBoard.BLL.Interfaces.Services;
using TaskBoard.BLL.Models.HistoryLogInputModels;

namespace TaskBoard.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HistoryLogController : ControllerBase
{
    private readonly IHistoryLogService _historyLogService;

    public HistoryLogController(IHistoryLogService historyLogService)
    {
        _historyLogService = historyLogService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllHistory()
    {
        var models = await _historyLogService.GetAllAsync();

        return Ok(models);
    }

    [HttpGet("{cardId}")]
    public async Task<IActionResult> GetAllHistoryByCard(Guid cardId)
    {
        var models = await _historyLogService.GetByCardIdAsync(cardId);

        return Ok(models);
    }
    
    [HttpPost("add")]
    public async Task<IActionResult> LogCardAdd(HistoryLogInputModel input)
    {
        await _historyLogService.LogAddCardAsync(input);

        return Ok();
    }
    
    [HttpPost("move")]
    public async Task<IActionResult> LogCardMove(HistoryLogInputModel input)
    {
        await _historyLogService.LogMoveCardAsync(input);

        return Ok();
    }
    
    [HttpPost("name")]
    public async Task<IActionResult> LogCardUpdateName(HistoryLogInputModel input)
    {
        await _historyLogService.LogUpdateCardNameAsync(input);

        return Ok();
    }
    
    [HttpPost("priority")]
    public async Task<IActionResult> LogCardUpdatePriority(HistoryLogInputModel input)
    {
        await _historyLogService.LogUpdateCardPriority(input);

        return Ok();
    }
    
    [HttpPost("delete")]
    public async Task<IActionResult> LogCardDelete(HistoryLogInputModel input)
    {
        await _historyLogService.LogDeleteCard(input);

        return Ok();
    }
}