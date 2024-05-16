using AutoMapper;
using TaskBoard.BLL.Interfaces.Services;
using TaskBoard.BLL.Models.InputModels;
using TaskBoard.BLL.Models.ViewModels.List;
using TaskBoard.DAL.Data.Entities;
using TaskBoard.DAL.Interfaces;

namespace TaskBoard.BLL.Services;

public class CardListService : ICardListService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IHistoryLogService _historyLog;

    public CardListService(IUnitOfWork unitOfWork, IMapper mapper, IHistoryLogService historyLog)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _historyLog = historyLog;
    }
    
    public async Task<IEnumerable<CardListVm>> GetAsync()
    {
        var entities = await _unitOfWork.CardList.GetAllAsyncNoTracking();
        
        foreach (var cardList in entities)
        {
            var cards = await _unitOfWork.Card.FindAsyncNoTracking(x => x.CardListId == cardList.Id, 
                new CancellationToken(), x => x.Priority);
            cardList.Cards = cards.OrderByDescending(x => x.DueDate).ToList();
        }
        
        var cardLists = _mapper.Map<IEnumerable<CardListVm>>(entities);

        return cardLists;
    }
    
    public async Task<IEnumerable<CardListVm>> GetByBoardAsync(Guid boardId)
    {
        var entities = await _unitOfWork.CardList.FindAsyncNoTracking(x => x.BoardId == boardId);
        
        foreach (var cardList in entities)
        {
            var cards = await _unitOfWork.Card.FindAsyncNoTracking(x => x.CardListId == cardList.Id, 
                new CancellationToken(), x => x.Priority);
            cardList.Cards = cards.OrderByDescending(x => x.DueDate).ToList();
        }
        
        var cardLists = _mapper.Map<IEnumerable<CardListVm>>(entities);

        return cardLists;
    }

    public async Task<IEnumerable<CardListVmList>> GetListAsync()
    {
        var entities = await _unitOfWork.CardList.GetAllAsyncNoTracking();

        var models = _mapper.Map<IEnumerable<CardListVmList>>(entities);

        return models;
    }
    
    public async Task<IEnumerable<CardListVmList>> GetListByBoardAsync(Guid boardId)
    {
        var entities = await _unitOfWork.CardList.FindAsyncNoTracking(x => x.BoardId == boardId);

        var models = _mapper.Map<IEnumerable<CardListVmList>>(entities);

        return models;
    }

    public async Task AddAsync(CardListInputModel input)
    {
        var entity = _mapper.Map<CardList>(input);

        await _unitOfWork.CardList.AddAsync(entity);
        await _unitOfWork.SaveChangeAsync();
    }

    public async Task UpdateAsync(CardListInputModel input)
    {
        var entity = _mapper.Map<CardList>(input);

        _unitOfWork.CardList.Update(entity);
        await _unitOfWork.SaveChangeAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var cardList = await _unitOfWork.CardList.FindAsync(x => x.Id == id, new CancellationToken(), x => x.Cards);
        var entity = cardList.First();
        var listName = entity.Name;
        var cards = entity.Cards;
        
        _unitOfWork.CardList.Remove(entity);
        int saveChange = await _unitOfWork.SaveChangeAsync();

        if (saveChange > 0)
            await _historyLog.LogDeleteCardWithList(cards.Select(x => x.Name), listName);
    }
}