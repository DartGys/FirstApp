using AutoMapper;
using TaskBoard.BLL.Interfaces.Services;
using TaskBoard.BLL.Models.HistoryLogInputModels;
using TaskBoard.BLL.Models.InputModels;
using TaskBoard.BLL.Models.ViewModels.Details;
using TaskBoard.DAL.Data.Entities;
using TaskBoard.DAL.Interfaces;

namespace TaskBoard.BLL.Services;

public class CardService : ICardService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IHistoryLogService _historyLog;

    public CardService(IUnitOfWork unitOfWork, IMapper mapper, IHistoryLogService historyLog)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _historyLog = historyLog;
    }

    public async Task<CardVmDetails> GetByIdAsync(Guid id)
    {
        var entity = await _unitOfWork.Card.GetById(id, CancellationToken.None, c => c.Priority, c => c.CardList, c => c.HistoryLogs);

        var card = _mapper.Map<CardVmDetails>(entity);

        return card;
    }

    public async Task AddAsync(CardInputModel input)
    {
        var entity = _mapper.Map<Card>(input);

        await _unitOfWork.Card.AddAsync(entity);
        var saveChange = await _unitOfWork.SaveChangeAsync();
        
        if(saveChange == 1)
            await _historyLog.LogAddCardAsync(entity.Id, entity.Name, entity.CardListId);
    }

    public async Task UpdateEntityAsync(CardInputModel input)
    {
        var entity = _mapper.Map<Card>(input);
        var entityBeforeUpd = await _unitOfWork.Card.GetById(entity.Id);
        
        await _unitOfWork.Card.UpdateEntity(entity);
        var saveChange = await _unitOfWork.SaveChangeAsync();

        if (saveChange == 0)
            await _historyLog.CardEqual(entityBeforeUpd, entity);
    }

    public async Task UpdateListAsync(Guid cardId, Guid listId)
    {
        var entityBeforeUpd = await _unitOfWork.Card.GetById(cardId);
        
        await _unitOfWork.Card.UpdateCardList(cardId, listId);
        var saveChange = await _unitOfWork.SaveChangeAsync();

        if (saveChange == 0)
            await _historyLog.LogMoveCardAsync(cardId, entityBeforeUpd.Name, entityBeforeUpd.CardListId, listId);
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await _unitOfWork.Card.GetById(id);
        
        _unitOfWork.Card.Remove(entity);
        int saveChange = await _unitOfWork.SaveChangeAsync();

        if (saveChange == 1)
            await _historyLog.LogDeleteCard(entity.Name, entity.CardListId);
    }
}