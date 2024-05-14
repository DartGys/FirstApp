using TaskBoard.BLL.Models.InputModels;
using TaskBoard.BLL.Models.ViewModels.List;

namespace TaskBoard.BLL.Interfaces.Services;

public interface ICardListService
{
    Task<IEnumerable<CardListVm>> GetAsync();
    Task<IEnumerable<CardListVm>> GetByBoardAsync(Guid boardId);
    Task<IEnumerable<CardListVmList>> GetListAsync();
    Task AddAsync(CardListInputModel input);
    Task UpdateAsync(CardListInputModel input);
    Task DeleteAsync(Guid id);
}