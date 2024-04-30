using Microsoft.AspNetCore.Mvc;
using TaskBoard.BLL.Interfaces.Services;
using TaskBoard.BLL.Models.InputModels;

namespace TaskBoard.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CardListController : ControllerBase
{
    private readonly ICardListService _cardListService;

    public CardListController(ICardListService cardListService)
    {
        _cardListService = cardListService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var models = await _cardListService.GetAsync();

        return Ok(models);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CardListInputModel input)
    {
        await _cardListService.AddAsync(input);

        var models = await _cardListService.GetAsync();
    
        return Ok(models);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] CardListInputModel input)
    {
        await _cardListService.UpdateAsync(input);

        var models = await _cardListService.GetAsync();

        return Ok(models);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _cardListService.DeleteAsync(id);

        var models = await _cardListService.GetAsync();

        return Ok(models);
    }
}