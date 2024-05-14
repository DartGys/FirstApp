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
    
    [HttpGet("board")]
    public async Task<IActionResult> GetAllHistoryByBoard(Guid id)
    {
        var models = await _historyLogService.GetByBoardAsync(id);

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
    
    [HttpGet("record/board/{lastRecord}")]
    public async Task<IActionResult> GetRecordsByBoard(Guid boardId, int lastRecord)
    {
        var models = await _historyLogService.GetTwentyRecordByBoard(boardId, lastRecord);

        return Ok(models);
    }
}