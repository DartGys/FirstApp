using Microsoft.AspNetCore.Mvc;
using TaskBoard.BLL.Interfaces.Services;
using TaskBoard.BLL.Models.InputModels;

namespace TaskBoard.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BoardController : ControllerBase
{
    private readonly IBoardService _boardService;

    public BoardController(IBoardService boardService)
    {
        _boardService = boardService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var models = await _boardService.GetAsync();

        return Ok(models);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] BoardInputModel input)
    {
        await _boardService.AddAsync(input);
        
        var models = await _boardService.GetAsync();

        return Ok(models);
    }

    [HttpPatch]
    public async Task<IActionResult> Update([FromBody] BoardInputModel input)
    {
        await _boardService.UpdateAsync(input);
        
        var models = await _boardService.GetAsync();

        return Ok(models);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _boardService.DeleteAsync(id);
        
        var models = await _boardService.GetAsync();

        return Ok(models);
    }
}