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

    public CardListService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<CardListVm>> GetAsync()
    {
        var entities = await _unitOfWork.CardList.GetAllAsync();

        var cardLists = _mapper.Map<IEnumerable<CardListVm>>(entities);

        return cardLists;
    }

    public async Task AddASync(CardListInputModel input)
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
        var entity = new CardList() { Id = id };
        
        _unitOfWork.CardList.Remove(entity);
        await _unitOfWork.SaveChangeAsync();
    }
}