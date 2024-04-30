using TaskBoard.BLL.Models.InputModels;
using TaskBoard.BLL.Models.ViewModels.Details;

namespace TaskBoard.BLL.Interfaces.Services;

public interface ICardService
{
    Task<CardVmDetails> GetByIdAsync(Guid id);
    Task<Guid> AddAsync(CardInputModel input);
    Task UpdateEntityAsync(CardInputModel model);
    Task UpdateListAsync(Guid cardId, Guid listId);
    Task DeleteAsync(Guid id);
    
}