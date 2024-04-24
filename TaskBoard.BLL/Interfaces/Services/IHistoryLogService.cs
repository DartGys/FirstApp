using TaskBoard.BLL.Models.HistoryLogInputModels;
using TaskBoard.BLL.Models.ViewModels.List;

namespace TaskBoard.BLL.Interfaces.Services;

public interface IHistoryLogService
{
    Task<IEnumerable<HistoryLogVm>> GetAllAsync();
    Task<IEnumerable<HistoryLogVm>> GetByCardIdAsync(Guid cardId);
    Task LogAddCardAsync(HistoryLogInputModel input);
    Task LogMoveCardASync(HistoryLogInputModel input);
    Task LogUpdateCardNameAsync(HistoryLogInputModel input);
    Task LogUpdateCardPriority(HistoryLogInputModel input);
    Task LogDeleteCard(HistoryLogInputModel input);
}