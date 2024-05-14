using TaskBoard.BLL.Models.InputModels;
using TaskBoard.BLL.Models.ViewModels.List;

namespace TaskBoard.BLL.Interfaces.Services;

public interface IBoardService
{
    Task<IEnumerable<BoardVm>> GetAsync();
    Task AddAsync(BoardInputModel input);
    Task UpdateAsync(BoardInputModel input);
    Task DeleteAsync(Guid id);
}