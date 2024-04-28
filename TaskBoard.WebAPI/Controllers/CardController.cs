using Microsoft.AspNetCore.Mvc;
using TaskBoard.BLL.Interfaces.Services;
using TaskBoard.BLL.Models.InputModels;

namespace TaskBoard.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CardController : ControllerBase
{
    private readonly ICardService _cardService;

    public CardController(ICardService cardService)
    {
        _cardService = cardService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var models = await _cardService.GetByIdAsync(id);

        return Ok(models);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CardInputModel input)
    {
        var id = await _cardService.AddAsync(input);

        return Ok(id);
    }

    [HttpPatch]
    public async Task<IActionResult> UpdateCard([FromBody] CardUpdateModel input)
    {
        await _cardService.UpdateEntityAsync(input);

        return Ok();
    }

    [HttpPatch("{cardId}/list/{listId}")]
    public async Task<IActionResult> UpdateListInCard(Guid cardId, Guid listId)
    {
        await _cardService.UpdateListAsync(cardId, listId);

        return Ok();
    }
    
    [HttpPatch("{cardId}/priority/{priorityId}")]
    public async Task<IActionResult> UpdatePriorityInCard(Guid cardId, Guid priorityId)
    {
        await _cardService.UpdatePriorityAsync(cardId, priorityId);

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        await _cardService.DeleteAsync(id);

        return Ok();
    }
}