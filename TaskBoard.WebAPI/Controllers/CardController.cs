using Microsoft.AspNetCore.Mvc;
using TaskBoard.BLL.Interfaces.Services;
using TaskBoard.BLL.Models.InputModels;
using TaskBoard.WebAPI.Validation;

namespace TaskBoard.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CardController : ControllerBase
{
    private readonly ICardService _cardService;
    private readonly ICardListService _cardListService;

    public CardController(ICardService cardService, ICardListService cardListService)
    {
        _cardService = cardService;
        _cardListService = cardListService;
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
        var error = Validator.Card(input);

        if (error.Length > 0)
        {
            return BadRequest(error);
        }
        
        await _cardService.AddAsync(input);

        var cardLists = await _cardListService.GetAsync();

        return Ok(cardLists);
    }

    [HttpPatch]
    public async Task<IActionResult> UpdateCard([FromBody] CardInputModel input)
    {
        var error = Validator.Card(input);

        if (error.Length > 0)
        {
            return BadRequest(error);
        }
        
        await _cardService.UpdateEntityAsync(input);

        var cardLists = await _cardListService.GetAsync();

        return Ok(cardLists);
    }

    [HttpPatch("{cardId}/list/{listId}")]
    public async Task<IActionResult> UpdateListInCard(Guid cardId, Guid listId)
    {
        if (cardId == Guid.Empty || listId == Guid.Empty)
        {
            return BadRequest("Card id or List id is empty");
        }
        
        await _cardService.UpdateListAsync(cardId, listId);

        var cardLists = await _cardListService.GetAsync();

        return Ok(cardLists);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        if (id == Guid.Empty)
        {
            return BadRequest("Card id is empty");
        }
        
        await _cardService.DeleteAsync(id);

        var cardLists = await _cardListService.GetAsync();

        return Ok(cardLists);
    }
}