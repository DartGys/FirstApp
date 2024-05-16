using Microsoft.AspNetCore.Mvc;
using TaskBoard.BLL.Interfaces.Services;
using TaskBoard.BLL.Models.InputModels;
using TaskBoard.WebAPI.Validation;

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
    
    [HttpGet("board/{id}")]
    public async Task<IActionResult> GetByBoard([FromRoute] Guid id)
    {
        var models = await _cardListService.GetByBoardAsync(id);

        return Ok(models);
    }

    [HttpGet("list")]
    public async Task<IActionResult> GetList()
    {
        var models = await _cardListService.GetListAsync();

        return Ok(models);
    }
    
    [HttpGet("list/board/{boardId}")]
    public async Task<IActionResult> GetList([FromRoute] Guid boardId)
    {
        var models = await _cardListService.GetListByBoardAsync(boardId);

        return Ok(models);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CardListInputModel input)
    {
        var error = Validator.CardList(input);

        if (error.Length > 0)
        {
            return BadRequest(error);
        }
        
        await _cardListService.AddAsync(input);

        var cardLists = await _cardListService.GetByBoardAsync(input.BoardId);
    
        return Ok(cardLists);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] CardListInputModel input)
    {
        var error = Validator.CardList(input);

        if (error.Length > 0)
        {
            return BadRequest(error);
        }

        await _cardListService.UpdateAsync(input);

        var cardLists = await _cardListService.GetByBoardAsync(input.BoardId);

        return Ok(cardLists);
    }

    [HttpDelete("{id}/board/{boardId}")]
    public async Task<IActionResult> Delete(Guid id, Guid boardId)
    {
        if (id == Guid.Empty)
        {
            return BadRequest("CardList id is empty");
        }
        
        await _cardListService.DeleteAsync(id);

        var cardLists = await _cardListService.GetByBoardAsync(boardId);

        return Ok(cardLists);
    }
}