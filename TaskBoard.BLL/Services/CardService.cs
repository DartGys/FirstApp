using AutoMapper;
using TaskBoard.BLL.Interfaces.Services;
using TaskBoard.BLL.Models.InputModels;
using TaskBoard.BLL.Models.ViewModels.Details;
using TaskBoard.DAL.Data.Entities;
using TaskBoard.DAL.Interfaces;

namespace TaskBoard.BLL.Services;

public class CardService : ICardService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CardService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CardVmDetails> GetByIdAsync(Guid id)
    {
        var entity = await _unitOfWork.Card.GetById(id, CancellationToken.None, c => c.Priority);

        var card = _mapper.Map<CardVmDetails>(entity);

        return card;
    }

    public async Task<Guid> AddAsync(CardInputModel input)
    {
        var entity = _mapper.Map<Card>(input);

        await _unitOfWork.Card.AddAsync(entity);
        await _unitOfWork.SaveChangeAsync();

        return entity.Id;
    }

    public async Task UpdateEntityAsync(CardInputModel model)
    {
        await _unitOfWork.Card.UpdateEntity(new Guid(model.Id), model.Name, model.Description, model.DueDate, model.PriorityId, model.CardListId);
        await _unitOfWork.SaveChangeAsync();
    }

    public async Task UpdateListAsync(Guid cardId, Guid listId)
    {
        await _unitOfWork.Card.UpdateCardList(cardId, listId);
        await _unitOfWork.SaveChangeAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = new Card() { Id = id };
        
        _unitOfWork.Card.Remove(entity);
        await _unitOfWork.SaveChangeAsync();
    }
}