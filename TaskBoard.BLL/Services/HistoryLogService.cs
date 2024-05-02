using AutoMapper;
using TaskBoard.BLL.Interfaces.Services;
using TaskBoard.BLL.Models.HistoryLogInputModels;
using TaskBoard.BLL.Models.ViewModels.List;
using TaskBoard.DAL.Data.Entities;
using TaskBoard.DAL.Interfaces;

namespace TaskBoard.BLL.Services;

public class HistoryLogService : IHistoryLogService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public HistoryLogService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<HistoryLogVm>> GetAllAsync()
    {
        var entities = await _unitOfWork.HistoryLog.GetAllAsync();

        var models = _mapper.Map<IEnumerable<HistoryLogVm>>(entities);

        return models;
    }

    public async Task<IEnumerable<HistoryLogVm>> GetByCardIdAsync(Guid cardId)
    {
        var entities = await _unitOfWork.HistoryLog.FindAsyncNoTracking(x => x.CardId == cardId);

        var models = _mapper.Map<IEnumerable<HistoryLogVm>>(entities);

        return models;
    }

    public async Task<IEnumerable<HistoryLogVm>> GetTwentyRecord(int lastRecord)
    {
        var entities = await _unitOfWork.HistoryLog.GetTwentyLogs(lastRecord);

        var models = _mapper.Map<IEnumerable<HistoryLogVm>>(entities);

        return models;
    }

    public async Task LogAddCardAsync(Guid cardId, string cardName, Guid listId)
    {
        var cardList = await _unitOfWork.CardList.GetById(listId);

        var model = new HistoryLogAddCard()
        {
            CardId = cardId,
            CardName = cardName,
            ListName = cardList.Name
        };
        
        var entity = _mapper.Map<HistoryLog>(model);

        await _unitOfWork.HistoryLog.AddAsync(entity);
        await _unitOfWork.SaveChangeAsync();
    }

    public async Task LogMoveCardAsync(Guid cardId, string cardName, Guid previousCardListId, Guid newCardListId)
    {
        var previousCardList = await _unitOfWork.CardList.GetById(previousCardListId);
        var newCardList = await _unitOfWork.CardList.GetById(newCardListId);

        var model = new HistoryLogUpdateCardList()
        {
            CardId = cardId,
            CardName = cardName,
            NewCardList = newCardList.Name,
            PreviousCardList = previousCardList.Name
        };
        
        var entity = _mapper.Map<HistoryLog>(model);

        await _unitOfWork.HistoryLog.AddAsync(entity);
        await _unitOfWork.SaveChangeAsync();
    }

    public async Task LogUpdateCardNameAsync(Guid cardId, string cardName, string previousCardName)
    {
        var model = new HistoryLogUpdateCardName()
        {
            CardId = cardId,
            CardName = cardName,
            PreviousCardName = previousCardName
        };
            
        var entity = _mapper.Map<HistoryLog>(model);

        await _unitOfWork.HistoryLog.AddAsync(entity);
        await _unitOfWork.SaveChangeAsync();
    }

    public async Task LogUpdateCardPriority(Guid cardId, string cardName, Guid previousCardPriorityId, Guid newCardPriorityId)
    {
        var previousCardPriority = await _unitOfWork.CardList.GetById(previousCardPriorityId);
        var newCardPriority = await _unitOfWork.CardList.GetById(newCardPriorityId);
        
        var model = new HistoryLogUpdateCardPriority()
        {
            CardId = cardId,
            CardName = cardName,
            PreviousCardPriority = previousCardPriority.Name,
            NewCardPriority = newCardPriority.Name
        };
        
        var entity = _mapper.Map<HistoryLog>(model);

        await _unitOfWork.HistoryLog.AddAsync(entity);
        await _unitOfWork.SaveChangeAsync();
    }

    public async Task LogDeleteCard(string cardName, Guid listId)
    {
        var cardList = await _unitOfWork.CardList.GetById(listId);

        var model = new HistoryLogDeleteCard()
        {
            CardId = null,
            CardName = cardName,
            ListName = cardList.Name
        };
        
        var entity = _mapper.Map<HistoryLog>(model);

        await _unitOfWork.HistoryLog.AddAsync(entity);
        await _unitOfWork.SaveChangeAsync();
    }

    public async Task LogDeleteCardWithList(IEnumerable<string> cardNames, string listName)
    {
        var model = new HistoryLogDeleteList()
        {
            CardNames = cardNames,
            ListName = listName,
        };

        var entity = _mapper.Map<HistoryLog>(model);

        await _unitOfWork.HistoryLog.AddAsync(entity);
        await _unitOfWork.SaveChangeAsync();
    }

    public async Task CardEqual(Card previousCard, Card newCard)
    {
        // log update name
        if (previousCard.Name != newCard.Name)
        {
            await this.LogUpdateCardNameAsync(newCard.Id, newCard.Name, previousCard.Name);
        }
        
        //log update list
        if (previousCard.CardListId != newCard.CardListId)
        {
            await this.LogMoveCardAsync(newCard.Id, newCard.Name, previousCard.CardListId, newCard.CardListId);
        }
        
        //log update priority
        if (previousCard.PriorityId != newCard.PriorityId)
        {
            await this.LogUpdateCardPriority(newCard.Id, newCard.Name, previousCard.PriorityId, newCard.PriorityId);
        }
    }
}