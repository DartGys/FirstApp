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

    [HttpGet("record/{lastRecord}")]
    public async Task<IActionResult> GetRecords(int lastRecord)
    {
        var models = await _historyLogService.GetTwentyRecord(lastRecord);

        return Ok(models);
    }
    
    [HttpPost("add")]
    public async Task<IActionResult> LogCardAdd(HistoryLogAddCard input)
    {
        await _historyLogService.LogAddCardAsync(input);

        var models = await _historyLogService.GetAllAsync();

        return Ok(models);
    }
    
    [HttpPost("move")]
    public async Task<IActionResult> LogCardMove(HistoryLogUpdateCardList input)
    {
        await _historyLogService.LogMoveCardAsync(input);

        var models = await _historyLogService.GetAllAsync();

        return Ok(models);
    }
    
    [HttpPost("name")]
    public async Task<IActionResult> LogCardUpdateName(HistoryLogUpdateCardName input)
    {
        await _historyLogService.LogUpdateCardNameAsync(input);

        var models = await _historyLogService.GetAllAsync();

        return Ok(models);
    }
    
    [HttpPost("priority")]
    public async Task<IActionResult> LogCardUpdatePriority(HistoryLogUpdateCardPriority input)
    {
        await _historyLogService.LogUpdateCardPriority(input);

        var models = await _historyLogService.GetAllAsync();

        return Ok(models);
    }
    
    [HttpPost("delete")]
    public async Task<IActionResult> LogCardDelete(HistoryLogDeleteCard input)
    {
        await _historyLogService.LogDeleteCard(input);

        var models = await _historyLogService.GetAllAsync();

        return Ok(models);
    }
}